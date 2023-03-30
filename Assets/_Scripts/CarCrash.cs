using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
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
        if (newTask == task.CarCrash)
        {
            AudioMgr.instance.PlayCrashAudio();
            TaskManager.instance.SetTaskCompleted(task.CarCrash);
            SceneChanger.instance.LoadNextScene(2);
        }
    }
}
