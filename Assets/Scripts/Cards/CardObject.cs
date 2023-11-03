using UnityEngine;

/// <summary>
/// The physical object of a card
/// </summary>
public class CardObject : MonoBehaviour
{
    [SerializeField] private Card card;

    public bool isDragging = false;
    public Vector3 offset = Vector3.zero;

    private void Update()
    {
        if (isDragging)
            DragCard();
    }

    public void BeginDragging(Vector3 clickLocation)
    {
        offset = transform.position - clickLocation;
        isDragging = true;
    }

    public void EndDragging()
    { 
        isDragging = false;
    }

    private void DragCard()
    {
        Vector3? mousePos = CardMovementController.GetMousePositionOnPlane();
        if (mousePos == null)
            return;
        
        // TODO: smoothly move towards the middle of the mouse selection instead of using an offset
        
        transform.position = (Vector3)mousePos + offset;
    }
}
