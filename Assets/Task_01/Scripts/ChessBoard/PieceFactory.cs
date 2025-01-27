using UnityEngine;

public class PieceFactory : IPieceFactory
{
    private int pieceCount;

    public PieceFactory(int count)
    {
        pieceCount = count;
    }

    public void CreatePieces(GameObject piecePrefab, int boardSize, IBoardController boardController)
    {
        var piecesParent = new GameObject("Pieces");
        var offset = -(float)boardSize / 2f;

        for (int i = 0; i < pieceCount; i++)
        {
            GameObject piece = Object.Instantiate(piecePrefab, new Vector3(offset + i % boardSize, 0.5f, offset + i / boardSize), Quaternion.identity, piecesParent.transform);
            piece.GetComponent<Piece>().Initialize(boardController);
            piece.name += $"_{i}";
        }
    }
}
