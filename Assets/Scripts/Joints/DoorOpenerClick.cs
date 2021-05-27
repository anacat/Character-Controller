using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenerClick : MonoBehaviour
{
    public float forceAmount = 1000;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void OnMouseDown() //chamado quando clicamos num objecto com collider
    {
        _rigidbody.AddForce(transform.forward * forceAmount, ForceMode.Acceleration);
    }
}
