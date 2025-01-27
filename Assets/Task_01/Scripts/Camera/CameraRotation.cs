using UnityEngine;

public class CameraRotation : IRotable
{
    private float rotationSpeed;
    private float minRotationAngle;
    private float maxRotationAngle;
    private Transform cameraTransform;

    public CameraRotation(Transform transform, float speed, float minAngle, float maxAngle)
    {
        cameraTransform = transform;
        rotationSpeed = speed;
        minRotationAngle = minAngle;
        maxRotationAngle = maxAngle;
    }

    public void Rotate(float deltaX)
    {
        //float angle = Mathf.Clamp(cameraTransform.eulerAngles.y + deltaX * rotationSpeed, minRotationAngle, maxRotationAngle);
        //cameraTransform.rotation = Quaternion.Euler(new Vector3(90f, angle, 0f));

        cameraTransform.Rotate(Vector3.up, deltaX * rotationSpeed, Space.World);
    }
}
