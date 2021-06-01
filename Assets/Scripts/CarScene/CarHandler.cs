using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarHandler : MonoBehaviour
{
    public GameObject cameraRig;
    public CarUserControl carUserControl;
    public CarController carController;

    [Header("Player")]
    public FPSController characterController;
    public Camera playerCamera;
    bool isNextToCar;

    public bool isActive;

    private void Start()
    {
        DeactivateCar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNextToCar && !isActive)
        {
            ActivateCar();
        }
        else if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            DeactivateCar();
        }
    }

    public void ActivateCar()
    {
        isActive = true;

        carController.enabled = true;
        carUserControl.enabled = true;
        cameraRig.SetActive(true);

        characterController.enabled = false;
        characterController.gameObject.SetActive(false);

        characterController.transform.parent = transform;
    }

    public void DeactivateCar()
    {
        isActive = false;

        carController.enabled = false;
        carUserControl.enabled = false;
        cameraRig.SetActive(false);

        characterController.gameObject.SetActive(true);
        characterController.enabled = true;

        characterController.transform.parent = null;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isNextToCar = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isNextToCar = false;
        }
    }
}
