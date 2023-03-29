using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using DG.Tweening;

public class DogMovement : MonoBehaviour
{
    public static DogMovement instance;

    public static event System.Action dogArrivedAtTarget;

    [SerializeField] Transform mouthPoint;
    [SerializeField] float groundY = -2.3f;
    [SerializeField] float moveSpeed = 3f;
    bool isMoving = false;
    Vector3 initialScale;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        initialScale = transform.localScale;
    }

    public void WalkTo(Vector3 position)
    {
        position.y = groundY;
        FlyTo(position);
    }

    public void FlyTo(Vector3 position)
    {
        if (isMoving) return;

        isMoving = true;

        float duration = Vector3.Distance(transform.position, position) / moveSpeed;
        transform.DOMove(position, duration).SetEase(Ease.Linear).onComplete += () => { isMoving = false; dogArrivedAtTarget?.Invoke(); };

        // flip in right fly dir
        if (position.x < transform.position.x)
        {
            Vector3 newScale = initialScale;
            newScale.x = -newScale.x;
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = initialScale;
        }
    }

    public Transform GetMouthTransform()
    {
        return mouthPoint;
    }

    private void OnEnable()
    {
        TaskManager.OnNewTask += OnNewTaskCallback;
        dogArrivedAtTarget += CheckIfOutOfScreen;
    }

    private void OnDisable()
    {
        TaskManager.OnNewTask -= OnNewTaskCallback;
        dogArrivedAtTarget -= CheckIfOutOfScreen;
    }

    private void OnNewTaskCallback(task completedTask, task newTask)
    {
        if (newTask == task.DogEscapeScreen)
        {
            Vector3 newPos = new Vector3(15, 0, 0);
            newPos.y = transform.position.y;
            WalkTo(newPos);
        }
    }

    private void CheckIfOutOfScreen()
    {
        if (TaskManager.instance.GetCurrentTask() == task.DogEscapeScreen)
        {
            TaskManager.instance.SetTaskCompleted(task.DogEscapeScreen);
        }
    }
}