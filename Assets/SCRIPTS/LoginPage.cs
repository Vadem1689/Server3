using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using TMPro;

public class LoginPage : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public Button loginButton;
    public Button registrationButton;
    public TMP_Text errorText;

    public static string userId = "";

    private FirebaseAuth auth;


    private bool allowLoginIfHasUser = false; //���� true, �� ����� ����������� ������������ �� ��������� ����� ������ �������.
    private int errorSuffixLenght = 28; //����� ������ ������ ������� �� ����� ������ ����� output ��� ���������� 

    void Start()
    {
        InitializeFirebase();
        loginButton.onClick.AddListener(delegate {
            login();
        });

        registrationButton.onClick.AddListener(delegate {
            register();
        });
    }

    private void login()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        var email = emailField.text;
        var password = passwordField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsFaulted)
            {
                errorText.text = task.Exception.GetBaseException().ToString().Remove(0, errorSuffixLenght);
                return;
            }

            if (task.IsCompleted)
            {
                // ����� ������ �������
                GoToGame();
                return;
            }
        }, taskScheduler);
    }

    private void register()
    {
        var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        var email = emailField.text;
        var password = passwordField.text;
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsFaulted)
            {
                errorText.text = task.Exception.GetBaseException().ToString().Remove(0, errorSuffixLenght);
                return;
            }

            if (task.IsCompleted)
            {
                GoToGame();
                return;
            }
        }, taskScheduler);
    }

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        if (auth.CurrentUser != null)
        {
            if (allowLoginIfHasUser == false)
            {
                auth.SignOut();
            }
            else
            {
                GoToGame();
            }
        }
    }

    private void GoToGame()
    {
        userId = auth.CurrentUser.UserId;
        SceneManager.LoadScene("BoardGame2");
    }
}
