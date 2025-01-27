using UnityEngine;

public class Piece : MonoBehaviour, IClickable
{
    private IBoardController boardController;

    public void Initialize(IBoardController controller)
    {
        boardController = controller;
    }

    public void OnMouseDown()
    {
        boardController.SelectPiece(gameObject);
    }
}