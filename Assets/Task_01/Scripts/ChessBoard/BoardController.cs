using UnityEngine;

public class BoardController : IBoardController
{
    private ISelectable selectedPiece;

    public void SelectPiece(ISelectable piece)
    {
        selectedPiece = piece;
        selectedPiece.OnSelect();
    }

    public void MovePieceToCell(GameObject cell)
    {
        if (selectedPiece != null)
        {
            selectedPiece.Transform.position = cell.transform.position + Vector3.up * 0.5f;

            Debug.Log($"{selectedPiece.Transform.name} moves to {cell.name}");
            DeselectPiece();
            return;
        }
        Debug.Log("Piece not selected");
    }

    public void DeselectPiece()
    {
        if(selectedPiece!=null)
        {
            selectedPiece.OnDeselect();
            selectedPiece = null;
            Debug.Log("Piece deselected");
        }
    }
}
