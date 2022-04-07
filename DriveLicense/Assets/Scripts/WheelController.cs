using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    // SerializeField : private  변수를 inspector 에서 접근가능하게 해주는 기능
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;



    public float acceleration = 50000f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 45f;


    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    /* 프레임을 기반으로 호출되는 Update 와 달리 Fixed Timestep에 설정된 값에 따라 일정한 간격으로 호출됩니다
    물리 효과가 적용된(Rigidbody) 오브젝트를 조정할 때 사용됩니다
    (Update는 불규칙한 호출임으로 물리엔진 충돌검사 등이 제대로 안될 수 있음)
    */
    private void FixedUpdate()
    {
        WheelControl();
        if (Public.DriveMode == 1)
            Acceleration();

        if (Public.ReverseMode == 1)
            ReverseAcceleration();

        if (Public.NeutralMode == 1)
        {
            if (currentAcceleration > 200f)
                currentAcceleration -= 10f;
        }
        if (Public.ParkingMode == 1)
            currentAcceleration = 0f;
      
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get wheel collider state.
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        // Set wheel transform state.
        trans.position = position;
        trans.rotation = rotation;

    }

    void Acceleration()
    {
        float velocity = Input.GetAxis("Vertical");
        // Get forward/reverse acceleration from the vertical axis (W and S keys)

        if(velocity >= 0)
            currentAcceleration = velocity * acceleration;
        Debug.Log(currentAcceleration);
            // Apply acceleration to front wheels

    }
    void ReverseAcceleration()
    {
        float velocity = Input.GetAxis("Vertical");
        // Get forward/reverse acceleration from the vertical axis (W and S keys)
        if (velocity <= 0)
            currentAcceleration = velocity * acceleration;
        Debug.Log(currentAcceleration);
        // Apply acceleration to front wheels

    }   



    void WheelControl()
    {
        // 바퀴의 회전속도 조절
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        // If we're pressing "C", give currentBreakingForce a value.
        if (Input.GetKey(KeyCode.C))
        {
            frontRight.motorTorque = 0f;
            frontLeft.motorTorque = 0f;

            currentBreakForce = breakingForce;
            if(currentAcceleration > 0)
            {
                currentAcceleration -= 100f;
            }

        }

        else
            currentBreakForce = 0f;


        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        // Take care of steering.
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);
    }



}
