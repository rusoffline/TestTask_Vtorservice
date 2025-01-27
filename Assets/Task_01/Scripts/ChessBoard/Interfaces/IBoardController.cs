using UnityEngine;

public interface IBoardController
{
    void SelectPiece(GameObject piece);
    void MovePieceToCell(GameObject cell);
    void DeselectPiece();
}
