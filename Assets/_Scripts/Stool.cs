using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour, IInteractable
{
    [SerializeField] Transform standPoint;
    public bool isEnabled = true;

    public void Pressed()
    {

    }

    public void Released()
    {
        if (isEnabled)
            DogMovement.instance.FlyTo(standPoint.position);
    }
}
