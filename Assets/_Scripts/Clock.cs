using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
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
        if (newTask == task.InteractClockFace)
        {
            GetComponent<Animation>().Play();
        }
        else if (completedTask == task.InteractClockFace)
        {
            GetComponent<Animation>().Stop();
        }
    }
}
