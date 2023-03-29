using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour, IInteractable
{
    public void Pressed()
    {

    }

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.InteractBird)
        {
            GetComponent<Animation>().Play();
            TaskManager.instance.SetTaskCompleted(task.InteractBird);
        }
    }

    public void BirdPushStickFromTree()
    {
        TaskManager.instance.SetTaskCompleted(task.BirdThrowStickFromTree);
    }

}
