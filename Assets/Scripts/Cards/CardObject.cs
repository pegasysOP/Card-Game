using UnityEngine;

/// <summary>
/// The physical object of a card
/// </summary>
public class CardObject : MonoBehaviour
{
    [SerializeField] private Card card;

    private bool isDragging = false;
    private Vector3 offset = Vector3.zero;

    private void Update()
    {
        if (isDragging)
            DragCard();
    }

    private void OnMouseDown()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag(Constants.CARD_TAG))
                {
                    if (hit.collider.gameObject.Equals(gameObject))
                    {
                        isDragging = true;
                        offset = transform.position - hit.point;
                        // gameObject.GetComponent<SortingGroup>().sortingLayerName = Constants.CARD_PICK_UP_LAYER;
                        return;
                    }
                }
            }
        }

    }
    private void OnMouseUp()
    {
        isDragging = false;

        // gameObject.GetComponent<SortingGroup>().sortingLayerName = Constants.DEFAULT_LAYER;

        //Return card to its original z coordinate
        //Vector3 newPosition = this.transform.position;
        //newPosition.z = 0f;
        //this.transform.position = newPosition;

        //Perform any logic to place the card down in a reasonable location. For now just do nothing. 

        //Trigger any events related to where it is placed down. For example in the arena we want to attack, do any visual effects and whatever else. 
    }

    private void DragCard()
    {
        //TODO: Add intertia or tweak delay on mouse drag compared to actual mouse position.

        //We must ensure that we are outside the clipping plane of the camera when we try and drag the object
        //Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)) + offset;
        //newPosition.z = this.transform.position.z;
        //this.transform.position = newPosition;

        Vector3? mousePos = GetMousePositionOnPlane();
        if (mousePos == null)
            return;
        
        // TODO: smoothly move towards the middle of the mouse selection instead of using an offset
        
        transform.position = (Vector3)mousePos + offset;
    }

    private Vector3? GetMousePositionOnPlane()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag(Constants.MOVEMENT_PLANE_TAG))
                    return hit.point;
            }
        }

        return null;
    }
}
