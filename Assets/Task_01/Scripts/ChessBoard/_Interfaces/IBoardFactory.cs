using UnityEngine;

public interface IBoardFactory
{
    void CreateBoard(GameObject whiteCell, GameObject blackCell, IBoardController boardController);
}
