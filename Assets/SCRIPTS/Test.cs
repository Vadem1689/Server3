using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        print(_rb.velocity.magnitude);
        _rb.AddForce(transform.forward * 10);
    }


}
