using UnityEngine;

public class DoorOpenener : MonoBehaviour
{
    public float forceAmount = 500f;
    private Rigidbody _rigidbody;

    public bool canOpen;

    void Start()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            _rigidbody.AddForce(transform.forward * forceAmount, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //verificamos se o jogador está dentro da área de interação
        if (other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}
