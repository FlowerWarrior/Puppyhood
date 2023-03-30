using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour, IInteractable
{
    public void Pressed()
    {

    }
    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.CollectLighter)
        {
            TaskManager.instance.SetTaskCompleted(task.CollectLighter);
        }
    }
}
