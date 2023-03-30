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

    private void OnEnable()
    {
        TaskManager.OnNewTask += OnNewTaskCallback;
    }

    private void OnDisable()
    {
        TaskManager.OnNewTask -= OnNewTaskCallback;
    }

    private void OnNewTaskCallback(task completedTask, task newTask)
    {
        if (newTask == task.EnterDoor)
        {
            GetComponent<Animation>().Play();
        }
    }
}
