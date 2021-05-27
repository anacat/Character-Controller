using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Camera playerCamera;
    public Transform cameraLookAt;

    public float mouseSensitivity;
    public Vector2 yRotationLimit = new Vector2(-35f, 60f);

    public bool invertMouseY = false;

    private float _mouseX;
    private float _mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
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

        playerCamera.transform.LookAt(cameraLookAt);

        //transform.rotation = Quaternion.Euler(0f, _mouseX, 0f);
        cameraLookAt.transform.localRotation = Quaternion.Euler(_mouseY, _mouseX, 0f);
    }
}
