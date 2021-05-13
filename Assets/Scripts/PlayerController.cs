using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rigidbody;

    public float jumpForce;
    public float rotateSpeed;
    public float speed;

    public float explosionForce;
    public float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        animator.SetFloat("speed", 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        //rigidbody.AddTorque(new Vector3(0, horizontalMovement, 0) * rotateSpeed); //aplica uma força de rotação no eixo dos Y
        rigidbody.rotation = Quaternion.Euler(rigidbody.rotation.eulerAngles + new Vector3(0, horizontalMovement, 0) * rotateSpeed);

        Vector3 newPosition = transform.forward * verticalMovement; //applies vertical movement
        //newPosition += transform.right * horizontalMovement; //applies horizontal movement

        newPosition.Normalize();

        newPosition *= speed * Time.fixedDeltaTime;

        //rigidbody.velocity = transform.forward * speed * verticalMovement; //move fazendo uso da velocidade em vez de alterar a posição

        rigidbody.position += newPosition;

        animator.SetFloat("speed", verticalMovement);

        if (Input.GetButtonDown("Jump"))
        {
            //rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            rigidbody.velocity = new Vector3(0, jumpForce, 0);

            animator.SetTrigger("jump");
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            //rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        //Debug.Log("vertical: " + verticalMovement, gameObject);
    }
}
