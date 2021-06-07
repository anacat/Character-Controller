using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float motorForce;
    public float breakForce;

    [Header("Steering")]
    public float maxSteeringAngle;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    [Header("Wheel Transforms")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    private float horizontalInput;
    private float verticalInput;
    private bool isBreaking;

    private float _steerAngle;
    private float _currentBreakForce;

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetButton("Jump");
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.fixedDeltaTime;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce * Time.fixedDeltaTime;
        rearLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.fixedDeltaTime;
        rearRightWheelCollider.motorTorque = verticalInput * motorForce * Time.fixedDeltaTime;

        _currentBreakForce = isBreaking ? breakForce : 0f;

        ApplyBreak();
    }

    private void ApplyBreak()
    {
        frontLeftWheelCollider.brakeTorque = _currentBreakForce;
        frontRightWheelCollider.brakeTorque = _currentBreakForce;
        rearLeftWheelCollider.brakeTorque = _currentBreakForce;
        rearRightWheelCollider.brakeTorque = _currentBreakForce;
    }

    private void HandleSteering()
    {
        _steerAngle = maxSteeringAngle * horizontalInput;

        frontLeftWheelCollider.steerAngle = _steerAngle;
        frontRightWheelCollider.steerAngle = _steerAngle;
    }

    private void UpdateWheels()
    {
        UpdateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
