using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
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
        if (newTask == task.WallUpAnim)
        {
            GetComponent<Animation>().Play();
        }
    }

    public void WallFullyOpened()
    {
        TaskManager.instance.SetTaskCompleted(task.WallUpAnim);
    }
}
