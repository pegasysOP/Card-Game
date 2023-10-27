using UnityEngine;

[System.Serializable]
public class Card : MonoBehaviour
{
    [SerializeField] private CardBase cardBase;
    [SerializeField] private int hp;

    private bool isDragging;
    private Vector3 offset;

    #region Attributes
    public string Name { get { return cardBase.cardName; } }
    public string Description { get { return cardBase.cardDescription; } }
    public int Hp { get { return hp; } }
    public int MaxHp { get { return cardBase.MaxHp; } }
    public int Damage { get { return cardBase.Damage; } }
    #endregion

    private void Start()
    {
        hp = cardBase.MaxHp;
        isDragging = false;
        offset = Vector3.zero;
    }

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
            if (hitInfo.collider.tag == "Card")
            {
                isDragging = true;
                offset = transform.position - hitInfo.point;
            }            
        }

    }
    private void OnMouseUp()
    {
        isDragging = false;

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