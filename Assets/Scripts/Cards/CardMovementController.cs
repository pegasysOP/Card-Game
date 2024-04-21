using UnityEngine;

public class CardMovementController : MonoBehaviour
{
    private CardObject selectedCard;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            MouseDown();

        if (Input.GetKeyUp(KeyCode.Mouse0))
            MouseUp();
    }

    private void MouseDown()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag(LayerDefines.DEFAULT_CARD_TAG))
                {
                    selectedCard = hit.collider.GetComponent<CardObject>();
                    if (selectedCard != null)
                    {
                        selectedCard.BeginDragging(hit.point);
                        return;
                    }

                }
            }
        }
    }

    private void MouseUp()
    {
        if (selectedCard == null)
            return;

        selectedCard.EndDragging();
        selectedCard = null;
    }

    /// <summary>
    /// Gets the world location of the mouses projection onto the card movement plane
    /// </summary>
    /// <returns>null if the plane is not hit</returns>
    public static Vector3? GetMousePositionOnPlane()
    {
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag(LayerDefines.MOVEMENT_PLANE_TAG))
                    return hit.point;
            }
        }

        return null;
    }
}