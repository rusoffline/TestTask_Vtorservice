using UnityEngine;

public class TouchInputHandler : ICameraInputHandler
{
    private readonly ICameraController cameraController;

    private Vector2 touchStartPos1;
    private Vector2 touchStartPos2;
    private float startAngle;
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

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                touchStartPos1 = touch1.position;
                touchStartPos2 = touch2.position;

                startAngle = Mathf.Atan2(touch2.position.y - touch1.position.y, touch2.position.x - touch1.position.x) * Mathf.Rad2Deg;
            }

            float angle = Mathf.Atan2(touch2.position.y - touch1.position.y, touch2.position.x - touch1.position.x) * Mathf.Rad2Deg;

            var rotationDelta = angle - startAngle;
            startAngle = angle;

            cameraController.RotateCamera(rotationDelta);

            //float averageDeltaX = (touch1.deltaPosition.x + touch2.deltaPosition.x) / 2f;
            //cameraController.RotateCamera(averageDeltaX);

            //var prevPos1 = touch1.position - touch1.deltaPosition;
            //var prevPos2 = touch2.position - touch2.deltaPosition;
            //var prevDir = prevPos2 - prevPos1;
            //var currDir = touch2.position - touch1.position;
            //var angle = Vector2.Angle(prevDir, currDir);
            //cameraController.RotateCamera(angle);

            float previousDistance = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
            float currentDistance = Vector2.Distance(touch1.position, touch2.position);
            float deltaDistance = currentDistance - previousDistance;

            cameraController.MoveCamera(deltaDistance);
        }
    }
}
