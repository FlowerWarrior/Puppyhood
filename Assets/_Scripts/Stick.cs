using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour, IInteractable
{
    public static event System.Action OnStickPickedup;

    [SerializeField] Transform grandmaAnimPoint;

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
        if (completedTask == task.BirdThrowStickFromTree)
        {
            GetComponent<Animation>().Play();
        }

        else if (completedTask == task.InteractGrandma)
        {
            transform.parent = null;
        }
    }

    public void StickFellOnGroundFromTree()
    {
        TaskManager.instance.SetTaskCompleted(task.StickAnim);
        AudioMgr.instance.PlaySound(AudioMgr.instance.LandedStick);
    }

    void Update()
    {
        if (TaskManager.instance.GetCurrentTask() == task.GrandmaAnim)
        {
            transform.position = grandmaAnimPoint.transform.position;
        }
    }

    public void Pressed()
    {

    }

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() != task.PickupStick) return;
        Transform targetTransform = DogMovement.instance.GetMouthTransform();
        transform.position = targetTransform.position;
        transform.parent = targetTransform;
        OnStickPickedup?.Invoke();

        TaskManager.instance.SetTaskCompleted(task.PickupStick);
    }
}
