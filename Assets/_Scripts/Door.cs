using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Pressed()
    {

    }

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.EnterDoor)
        {
            TaskManager.instance.SetTaskCompleted(task.EnterDoor);
            SceneChanger.instance.LoadNextScene(0);
        }
    }
}
