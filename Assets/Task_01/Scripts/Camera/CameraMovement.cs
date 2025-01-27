using UnityEngine;

public class CameraMovement : IMovable
{
    private float moveSpeed;
    private float minHeight;
    private float maxHeight;
    private Transform cameraTransform;

    public CameraMovement(Transform transform, float speed, float min, float max)
    {
        cameraTransform = transform;
        moveSpeed = speed;
        minHeight = min;
        maxHeight = max;
    }

    public void Move(float deltaDistance)
    {
        float newHeight = Mathf.Clamp(cameraTransform.position.y - deltaDistance * moveSpeed, minHeight, maxHeight);
        Vector3 newPosition = new Vector3(cameraTransform.position.x, newHeight, cameraTransform.position.z);
        cameraTransform.position = newPosition;
    }
}