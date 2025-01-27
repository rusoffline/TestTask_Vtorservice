using UnityEngine;

public class TouchInputHandler : ICameraInputHandler
{
    private readonly ICameraController cameraController;

    public TouchInputHandler(ICameraController controller)
    {
        cameraController = controller;
    }

    public void ProcessInput()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            float averageDeltaX = (touch1.deltaPosition.x + touch2.deltaPosition.x) / 2f;
            cameraController.RotateCamera(averageDeltaX);

            float previousDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);
            float deltaDistance = currentDistance - previousDistance;

            cameraController.MoveCamera(deltaDistance);
        }
    }
}
