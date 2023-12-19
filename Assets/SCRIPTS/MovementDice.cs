using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BoardGame
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Dice))]
    public class MovementDice : MonoBehaviour
    {
        [SerializeField] private float pushForce;
        [SerializeField] private float rotationForce;
        [SerializeField] private Transform _startPosition;

        private Rigidbody _rb;
        private Dice _dice;

        private void Start()
        {
            _dice = GetComponent<Dice>();
            _rb = GetComponent<Rigidbody>();
        }

        public void RollDice()
        {
            transform.position = _startPosition.position;

            float randomAngle = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0f, randomAngle, 0f);

            _rb.useGravity = true;
            _rb.AddForce(transform.forward * pushForce);

            _rb.AddTorque(new Vector3(2, 3, 1) * rotationForce);
            _rb.velocity = Vector3.one;

            _dice.ChangeStatusMovement();
        }

    }

}

