using UnityEngine;

public class BoardController : IBoardController
{
    private GameObject selectedPiece;

    public void SelectPiece(GameObject piece)
    {
        selectedPiece = piece;
    }

    public void MovePieceToCell(GameObject cell)
    {
        if (selectedPiece != null)
        {
            selectedPiece.transform.position = cell.transform.position + Vector3.up * 0.5f;

            Debug.Log($"{selectedPiece.name} moves to {cell.name}");
            selectedPiece = null;
            return;
        }
        Debug.Log("Piece not selected");
    }

    public void DeselectPiece()
    {
        selectedPiece = null;
        Debug.Log("Piece deselected");
    }
}
