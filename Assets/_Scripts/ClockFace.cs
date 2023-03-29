using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFace : MonoBehaviour
{
    [SerializeField] GameObject clockFaceCanvas;

    public void Pressed()
    {

    }

    public void Released()
    {
        Instantiate(clockFaceCanvas);
    }
}
