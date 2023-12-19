using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    public float moveSpeed;

    private bool looksRight = true;


    //Online
    private Vector3 lastSentPosition;
    private float delay = 1f;
    public static string username = "";
    private string userId = "";

    private IEnumerator sendPosition()
    {
        yield return new WaitForSeconds(delay);

        if (transform.position.x != lastSentPosition.x || transform.position.y != lastSentPosition.y || transform.position.z != lastSentPosition.z)
        {
            lastSentPosition = transform.position;
            FirebaseAPIs.PostPlayer(new PlayerPosition(transform.position.x, transform.position.y, transform.position.z, username, userId), () => { });
        }

        StartCoroutine(sendPosition());
    }

    void Start()
    {
        userId = LoginPage.userId;
        rigidbody = GetComponent<Rigidbody>();

        //Online
        //username = Random.Range(0,10000).ToString();
        StartCoroutine(sendPosition());
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        if ((movement.x > 0) && !looksRight)
        {
            Flip();
        }
        else if ((movement.x < 0) && looksRight)
        {
            Flip();
        }

        //if (movement.x != 0 || movement.y != 0)
        //{
        //    animator.Play("GladiatorRun");
        //}
        //else animator.Play("GladiatorIdle");

    }

    private void Flip()
    {
        looksRight = !looksRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
