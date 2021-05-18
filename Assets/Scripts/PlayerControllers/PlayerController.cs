using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    public Animator animator;
    public Rigidbody rigidbody;

    public float jumpForce;
    public float rotateSpeed;
    public float speed;

    public bool isGrounded;

    public UnityEvent OnCoinCaught;

    private float verticalMovement;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        animator.SetFloat("speed", 0f);
    }

    private void Update()
    {
        //Inputs sempre no Update

        verticalMovement = Input.GetAxis("Vertical");
        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.velocity = new Vector3(0, jumpForce, 0);

            animator.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), -transform.up, Color.red, Time.deltaTime);

        //verifica se o jogador tem os pés no chão, damos um offset à posição para ter a certeza que o raycast passa no collider e não por baixo dele
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), -transform.up, 1f)) 
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //rigidbody.AddTorque(new Vector3(0, horizontalMovement, 0) * rotateSpeed); //aplica uma força de rotação no eixo dos Y

        rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0, horizontalMovement, 0) * rotateSpeed);

        //Vector3 strafe = transform.right * horizontalMovement; //applies horizontal movement
        Vector3 newPosition = transform.forward * verticalMovement; //applies vertical movement
        //newPosition += strafe;
    
        newPosition.Normalize();

        newPosition *= speed * Time.fixedDeltaTime;

        //rigidbody.velocity = transform.forward * speed * verticalMovement; //move fazendo uso da velocidade em vez de alterar a posição

        rigidbody.position += newPosition;

        animator.SetFloat("speed", verticalMovement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Ground"))
        //{
        //    isGrounded = true;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.collider.CompareTag("Ground"))
        //{
        //    isGrounded = false;
        //}
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);

            if (OnCoinCaught != null) //Se tiver um evento no inspector, o mesmo é chamado
            {
                OnCoinCaught.Invoke();
            }

            //gameManager.coinsCaught++;
        }
    }
}
