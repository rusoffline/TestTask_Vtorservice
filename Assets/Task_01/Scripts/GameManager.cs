using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject whiteCellPrefab;
    [SerializeField] private GameObject blackCellPrefab;
    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private int boardSize = 8;
    private IBoardController boardController;
    private IBoardFactory boardFactory;
    private IPieceFactory pieceFactory;

    void Start()
    {
        boardController = new BoardController();

        boardFactory = new BoardFactory(boardSize); 
        pieceFactory = new PieceFactory(1);

        boardFactory.CreateBoard(whiteCellPrefab, blackCellPrefab, boardController);
        pieceFactory.CreatePieces(piecePrefab, boardSize, boardController);
    }
}
