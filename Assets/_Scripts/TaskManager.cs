using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    private task[] tasksOrder =
    { task.GrandmaAnim,
      task.PickupStick,
      task.InteractGrandma,
      task.GrandmaAnim,
      task.InteractBird,
      task.BirdThrowStickFromTree,
      task.StickAnim,
      task.PickupStick,
      task.InteractGrandma,
      task.DisablePlayerControls,
      task.GrandmaAnim,
      task.DogEscapeScreen,
      task.CarCrash,
      task.EnablePlayerControls,
      task.CollectDogPart,
      task.EnterDoor,
      task.UnlockMusicPinCode,
      task.DisablePlayerControls,
      task.WallUpAnim,
      task.EnablePlayerControls,
      task.TuneTheRadio,
      task.UnlockChest,
      task.EnterDoor

    };
    public int currentTaskID = 0;

    public static event System.Action<task, task> OnNewTask;

    private void Awake()
    {
        instance = this;
    }

    public void SetTaskCompleted(task taskCompleted)
    {
        if (tasksOrder[currentTaskID] == taskCompleted)
        {
            currentTaskID++;
            OnNewTask?.Invoke(taskCompleted, tasksOrder[currentTaskID]);
            Debug.Log($"new task is {currentTaskID}");
        }
    }

    public task GetCurrentTask()
    {
        return tasksOrder[currentTaskID];
    }
}

public enum task
{
    GrandmaAnim,
    PickupStick,
    InteractGrandma,
    InteractBird,
    BirdThrowStickFromTree,
    StickAnim,
    DogEscapeScreen,
    DisablePlayerControls,
    EnablePlayerControls,
    CarCrash,
    CollectDogPart,
    EnterDoor,
    UnlockMusicPinCode,
    WallUpAnim,
    TuneTheRadio,
    InteractClockFace,
    UnlockChest
}
