using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardGame
{
    [RequireComponent(typeof(Rigidbody))]

    public class Dice : MonoBehaviour
    {
        [SerializeField] private Transform[] _diceFaces;

        private Rigidbody _rb;
        private int _diceIndex = -1;
        private bool _isStartMovement;

        public Action<int> OnDiceResult;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_isStartMovement && _rb.velocity.sqrMagnitude == 0)
            {
                _isStartMovement = false;
                GetNumberOnFace();
            }
        }
        private int GetNumberOnFace()
        {
            var topFace = 0;

            float lastYPosition = _diceFaces[0].position.y;

            for (int i = 0; i < _diceFaces.Length; i++)
            {
                if (_diceFaces[i].position.y > lastYPosition)
                {
                    lastYPosition = _diceFaces[i].position.y;
                    topFace = i;
                }
            }
            OnDiceResult?.Invoke(topFace + 1);
            return topFace + 1;
        }

        public void ChangeStatusMovement()
        {
            _isStartMovement = true;
        }
    }
}

