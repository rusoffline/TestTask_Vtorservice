using UnityEngine;

public class CameraManager : MonoBehaviour, ICameraController
{
    [SerializeField] private Camera cam;
    [Header("Rotation settings:")]
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private float minRotationAngle = -60f;
    [SerializeField] private float maxRotationAngle = 60f;

    [Header("Move settings:")]
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float minHeight = 5f;
    [SerializeField] private float maxHeight = 20f;

    private IRotable cameraRotation;
    private IMovable cameraMovement;
    private ICameraInputHandler inputHandler;

    private void Start()
    {
        cameraRotation = new CameraRotation(cam.transform, rotationSpeed, minRotationAngle, maxRotationAngle);
        cameraMovement = new CameraMovement(cam.transform, moveSpeed, minHeight, maxHeight);

        inputHandler = new TouchInputHandler(this);
    }

    private void Update()
    {
        inputHandler.ProcessInput();
    }

    public void RotateCamera(float deltaX)
    {
        cameraRotation.Rotate(deltaX);
    }

    public void MoveCamera(float deltaDistance)
    {
        cameraMovement.Move(deltaDistance);
    }
}
