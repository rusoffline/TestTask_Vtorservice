using UnityEngine;

public interface IBoardController
{
    void SelectPiece(ISelectable piece);
    void MovePieceToCell(GameObject cell);
    void DeselectPiece();
}
