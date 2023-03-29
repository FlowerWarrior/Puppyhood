using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour, IInteractable
{
    [SerializeField] Transform standPoint;

    public void Pressed()
    {

    }

    public void Released()
    {
        DogMovement.instance.FlyTo(standPoint.position);
    }
}
