using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 mousePosition;
    private float deltaX;
    private bool canMove = false;
    public float minXPosition;
    public float maxXPosition;
    public bool isFollowing = false;
    

    void Update()
    {
        isFollowing = Input.GetMouseButton(0);
        if (isFollowing)
        {
            if (!canMove)
            {
                canMove = true;
                mousePosition = Input.mousePosition;
                deltaX = Camera.main.ScreenToWorldPoint(mousePosition).x - transform.position.x;
            }
        }
        else
        {
            canMove = false;
        }

        if (canMove)
        {
            Vector2 newPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - deltaX, transform.position.y);
            if (newPosition.x >= minXPosition && newPosition.x <= maxXPosition)
            {
                transform.position = newPosition;
            }
            else if (newPosition.x < minXPosition)
            {
                transform.position = new Vector2(minXPosition, transform.position.y);
            }
            else if (newPosition.x > maxXPosition)
            {
                transform.position = new Vector2(maxXPosition, transform.position.y);
            }
        }
    }
}
