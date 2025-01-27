using UnityEngine;

public class Piece : MonoBehaviour, IClickable, ISelectable
{
    private IBoardController boardController;
    private Renderer rend;
    private Color originalColor;
    [SerializeField] private Color selectedColor = Color.yellow;

    public void Initialize(IBoardController controller)
    {
        boardController = controller;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void OnMouseDown()
    {
        boardController.SelectPiece(this);
    }

    public void OnDeselect()
    {
        rend.material.color = originalColor;
    }

    public void OnSelect()
    {
        rend.material.color = selectedColor;
    }

    public Transform Transform => transform;
}