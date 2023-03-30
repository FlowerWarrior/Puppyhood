using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 mousePosition;
    private float deltaX;
    private bool canMove = false;
    public float minXPosition;
    public float maxXPosition;    

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - deltaX,minXPosition,maxXPosition), transform.position.y);           
        }
    }
}
