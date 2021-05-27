using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource footstepsAudioSource;
    public AudioSource sfxAudioSource;

    public GameObject bulletPrefab;

    [Header("Movement Parameters")]
    public float gravity = -9.8f;
    public float movementSpeed = 1f;

    [Header("Mouse Parameters")]
    [Range(0, 10)] public float mouseSensitivity;
    public bool invertMouseY;
    public Vector2 yRotationLimit = new Vector2(-35f, 60f);

    [Header("Audio Parameters")]
    public AudioClip shotAudio;

    private Camera playerCamera;
    private CharacterController characterController;

    private float _mouseX;
    private float _mouseY;
    private float _horizontalMovement;
    private float _verticalMovement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        GetKeyboardInput();
        GetMouseInput();

        ShootCoin();

        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, playerCamera.ScreenToWorldPoint(Input.mousePosition), playerCamera.transform.rotation);
        bullet.GetComponent<BulletController>().gameManager = gameManager;

        sfxAudioSource.PlayOneShot(shotAudio);
    }

    private void ShootCoin()
    {
        Debug.DrawRay(playerCamera.ScreenToWorldPoint(Input.mousePosition), playerCamera.transform.forward * 100f, Color.red, Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.CompareTag("Coin"))
                {
                    Destroy(hit.collider.gameObject);
                    gameManager.OnCoinCaught();
                }
            }
        }
    }

    private void GetMouseInput()
    {
        _mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;

        if (invertMouseY)
        {
            _mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        else
        {
            _mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        }

        _mouseY = Mathf.Clamp(_mouseY, yRotationLimit.x, yRotationLimit.y);

        playerCamera.transform.localRotation = Quaternion.Euler(_mouseY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, _mouseX, 0f);
    }

    private void GetKeyboardInput()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        Vector3 applyGravity = transform.up * gravity;

        Vector3 forward = transform.forward * _verticalMovement;
        Vector3 strafe = transform.right * _horizontalMovement;
        Vector3 movement = ((forward + strafe).normalized + applyGravity) * movementSpeed * Time.deltaTime;

        characterController.Move(movement);

        if ((Mathf.Abs(_horizontalMovement) > 0.1f || Mathf.Abs(_verticalMovement) > 0.1f) && !footstepsAudioSource.isPlaying)
        {
            footstepsAudioSource.Play();
        }
        else if(_horizontalMovement == 0 && _verticalMovement == 0)
        {
            footstepsAudioSource.Stop();
        }
    }
}
