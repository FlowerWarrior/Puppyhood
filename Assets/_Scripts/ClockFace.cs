using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockFace : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject clockFaceCanvas;

    public void Pressed()
    {

    }

    public void Released()
    {
        Instantiate(clockFaceCanvas);
        TaskManager.instance.SetTaskCompleted(task.InteractClockFace);
    }
}
