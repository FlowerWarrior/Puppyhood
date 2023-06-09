using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using DG.Tweening;

public class DogMovement : MonoBehaviour
{
    public static DogMovement instance;

    public static event System.Action dogArrivedAtTarget;

    [SerializeField] AudioSource audioWheelLoop;
    [SerializeField] AudioSource audioStepsLoop;
    [SerializeField] AudioSource audioGhostMoveLoop;
    [SerializeField] Transform mouthPoint;
    [SerializeField] float groundY = -2.3f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform spriteTransform;
    bool isMoving = false;
    [SerializeField] bool isGhost = false;
    [SerializeField] float animScale = 0.2f;
    [SerializeField] float animSpeed = 1.5f;
    [SerializeField] SpriteRenderer dogSpriteRend;
    [SerializeField] SpriteAnimation spriteAnimator;
    [SerializeField] Sprite zombieDog;
    Vector3 initialScale;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        initialScale = transform.localScale;
        spriteAnimator.enabled = false;
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
        if (isGhost)
        {
            audioGhostMoveLoop.Play();
        }
        else
        {
            audioWheelLoop.Play();
            audioStepsLoop.Play();
            spriteAnimator.enabled = true;
        }

        
        float duration = Vector3.Distance(transform.position, position) / moveSpeed;
        transform.DOMove(position, duration).SetEase(Ease.Linear).onComplete += () => { isMoving = false; 
            dogArrivedAtTarget?.Invoke();
            if (isGhost)
            {
                audioGhostMoveLoop.Stop();
            }
            else
            {
                audioWheelLoop.Stop();
                audioStepsLoop.Stop();
                spriteAnimator.enabled = false;
            }
        };

        if (isGhost)
        {
            AudioMgr.instance.PlaySound(AudioMgr.instance.ghostMove);
        }

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

        else if (newTask == task.TurnPlayerToZombie)
        {
            isMoving = true;

            Vector3 position = Vector3.zero;
            float duration = Vector3.Distance(transform.position, position) / moveSpeed;
            transform.DOMove(position, duration).SetEase(Ease.Linear).onComplete += () => { GetComponent<Animation>().Play(); isMoving = false; dogArrivedAtTarget?.Invoke(); };

            // flip in right fly dir
            if (0 < transform.position.x)
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
    }

    public void ChangeSpriteToZombie()
    {
        dogSpriteRend.sprite = zombieDog;
    }

    public void FinalAnimCompleted()
    {
        SceneChanger.instance.LoadNextScene(0);
    }

    private void CheckIfOutOfScreen()
    {
        if (TaskManager.instance.GetCurrentTask() == task.DogEscapeScreen)
        {
            TaskManager.instance.SetTaskCompleted(task.DogEscapeScreen);
        }
    }

    private void Update()
    {
        if (isGhost)
        {
            spriteTransform.localPosition = new Vector3(0, Mathf.Sin(Time.time * animSpeed) * animScale, 0);
        }
    }
}