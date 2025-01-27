using UnityEngine;

public class Cell : MonoBehaviour, IClickable
{
    private IBoardController boardController;

    public void Initialize(IBoardController controller)
    {
        boardController = controller;
    }

    public void OnMouseDown()
    {
        boardController.MovePieceToCell(gameObject);
    }
}
