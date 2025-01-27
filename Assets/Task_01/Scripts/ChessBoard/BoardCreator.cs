using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [SerializeField] private Vector2Int chessSize = new Vector2Int(8, 8);
    [SerializeField] private GameObject whiteCell;
    [SerializeField] private GameObject blackCell;

    private void Start()
    {
        CreateChessBoard();
    }

    private void CreateChessBoard()
    {
        if (chessSize.x <= 0 || chessSize.y <= 0)
        {
            Debug.LogError("the size of the chessboard must be greater than 0!");
            return;
        }

        if (whiteCell == null || blackCell == null)
        {
            Debug.LogError("missing prefabs!");
            return;

        }

        var startX = -(float)chessSize.x / 2f;
        var startY = -(float)chessSize.y / 2f;

        for (int x = 0; x < chessSize.x; x++)
        {
            for (int y = 0; y < chessSize.y; y++)
            {
                var isWhite = (x + y) % 2 == 0;
                var callPref = isWhite ? whiteCell : blackCell;
                GameObject cell = Instantiate(callPref);
                cell.transform.position = new Vector3(startX + x, 0, startY + y);
                cell.transform.parent = transform;
            }
        }
    }
}
