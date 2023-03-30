using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableStool : MonoBehaviour, IInteractable
{
    private Vector2 mousePosition;
    private float deltaX;
    private bool canMove = false;
    public float minXPosition;
    public float maxXPosition;

    [SerializeField] Transform standPoint;
    public bool isFollowingMouse = true;
    bool isInPlace = false;

    public void Pressed()
    {
        if (!isInPlace)
            isFollowingMouse = true;
    }

    public void Released()
    {
        if (isInPlace)
        {
            DogMovement.instance.FlyTo(standPoint.position);
        }

        if (transform.position.x >= maxXPosition)
        {
            isInPlace = true;
            AudioMgr.instance.PlaySound(AudioMgr.instance.ladderMoved);
        }

        isFollowingMouse = false;
    }

    void Update()
    {
        if (isFollowingMouse)
        {
            transform.position = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - deltaX, minXPosition, maxXPosition), transform.position.y);
        }
    }
}
