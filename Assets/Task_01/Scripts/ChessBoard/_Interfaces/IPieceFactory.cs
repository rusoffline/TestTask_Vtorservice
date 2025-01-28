using UnityEngine;

public interface IPieceFactory
{
    void CreatePieces(GameObject piecePrefab, int boardSize, IBoardController boardController);
}