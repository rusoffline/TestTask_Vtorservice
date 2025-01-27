using Unity.VisualScripting;
using UnityEngine;

public class BoardFactory : IBoardFactory
{
    private int boardSize;

    public BoardFactory(int size)
    {
        boardSize = size;
    }

    public void CreateBoard(GameObject whiteCell, GameObject blackCell, IBoardController boardController)
    {
        var boardParent = new GameObject("Board");
        boardParent.transform.position = Vector3.zero;

        var offset = -(float)boardSize / 2f;

        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                var isWhite = (x + y) % 2 == 0;
                var callPref = isWhite ? whiteCell : blackCell;

                GameObject cell = Object.Instantiate(callPref, new Vector3(offset + x, 0, offset + y), Quaternion.identity, boardParent.transform);
                cell.GetComponent<Cell>().Initialize(boardController);
                cell.name += $"_{x}_{y}";
            }
        }
    }
}
