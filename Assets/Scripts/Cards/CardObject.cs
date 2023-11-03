using UnityEngine;
using UnityEngine.Rendering;

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
        {
            DragCard();
        }
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag(Constants.CARD_TAG))
            {
                isDragging = true;
                offset = transform.position - hitInfo.point;
                this.gameObject.GetComponent<SortingGroup>().sortingLayerName = Constants.CARD_PICK_UP_LAYER;
            }
        }

    }
    private void OnMouseUp()
    {
        isDragging = false;

        this.gameObject.GetComponent<SortingGroup>().sortingLayerName = Constants.DEFAULT_LAYER;

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
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)) + offset;
        newPosition.z = this.transform.position.z;
        this.transform.position = newPosition;
    }
}
