using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]

public class MouseLook : MonoBehaviour
{
    public static bool invActivated = false; // активен ли инвентарь
    public enum RotationAxes { MouseXandY = 0, MouseX = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sentitivityX = 2f;
    public float sentitivityY = 2f;

    public float minimumX = -360f;
    public float maximumX = 360f;

    public float minimumY = -360f;
    public float maximumY = 360f;

    float rotationX = 0f;
    float rotationY = 0f;

    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

    // Update is called once per frame
    void Update()
    {
        if (invActivated == false) // если инвентарь отключен, можем вращать головой
        {
            if (axes == RotationAxes.MouseXandY)
            {
                rotationX += Input.GetAxis("Mouse X") * sentitivityX;
                rotationX += Input.GetAxis("Mouse Y") * sentitivityY;

                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                rotationY = ClampAngle(rotationY, minimumY, maximumY);

                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

                transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
            else if (axes == RotationAxes.MouseX)
            {
                rotationX += Input.GetAxis("Mouse X") * sentitivityX;
                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                transform.localRotation = originalRotation * xQuaternion;
            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationY += Input.GetAxis("Mouse Y") * sentitivityY;
                rotationY = ClampAngle(rotationY, minimumY, maximumY);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                transform.localRotation = originalRotation * yQuaternion;
            }
        }
    }
}
