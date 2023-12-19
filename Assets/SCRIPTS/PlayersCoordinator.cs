using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardGame
{
    public class PlayersCoordinator : MonoBehaviour
    {
        [SerializeField] private List<PlayerMovement> _players;
        [SerializeField] private Dice _dice;

        private int _indexCurrentPlayer = 0;

        private void OnEnable()
        {
            _dice.OnDiceResult += AssignMovement;
        }

        private void OnDisable()
        {
            _dice.OnDiceResult -= AssignMovement;
        }

        private void AssignMovement(int countPointMovement)
        {
            if (_indexCurrentPlayer >= _players.Count)
            {
                _indexCurrentPlayer = 0;
            }

            _players[_indexCurrentPlayer].StartCoroutineMovement(countPointMovement);
            _indexCurrentPlayer++;

        }
    }

}
