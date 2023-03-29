using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour, IInteractable
{
    public static event System.Action OnStickLanded;

    [SerializeField] AnimationClip[] animClips;
    int currentAnimID = 0;

    private void OnEnable()
    {
        TaskManager.OnNewTask += OnNewTaskCallback;
    }

    private void OnDisable()
    {
        TaskManager.OnNewTask -= OnNewTaskCallback;
    }

    void Start()
    {
        GetComponent<Animation>().clip = animClips[currentAnimID];
        GetComponent<Animation>().Play();
    }

    private void OnNewTaskCallback(task completedTask, task newTask)
    {
        if (newTask == task.GrandmaAnim)
        {
            currentAnimID++;
            GetComponent<Animation>().clip = animClips[currentAnimID];
            GetComponent<Animation>().Play();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.GetChild(0).GetChild(0).position, 0.15f);
    }

    public void GrandmaAnimEnd()
    {
        OnStickLanded?.Invoke();
        TaskManager.instance.SetTaskCompleted(task.GrandmaAnim);
    }

    public void Pressed()
    {

    }

    public void Released()
    {
        TaskManager.instance.SetTaskCompleted(task.InteractGrandma);
    }
}
