using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] float interactDistance = 10;
    IInteractable currentInteractable = null;
    bool playerControlsEnabled = true;
    public bool isUIPanelOpened = false;

    public static ClickManager instance;
    private void Awake()
    {
        instance = this;
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
        if (newTask == task.DisablePlayerControls)
        {
            playerControlsEnabled = false;
            TaskManager.instance.SetTaskCompleted(task.DisablePlayerControls);
        }
        else if (newTask == task.EnablePlayerControls)
        {
            playerControlsEnabled = true;
            TaskManager.instance.SetTaskCompleted(task.EnablePlayerControls);
        }
    }

    private void Update()
    {
        if (!playerControlsEnabled) return;
        if (isUIPanelOpened) return;

        if (Input.GetMouseButtonDown(0) && Camera.main != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(DogMovement.instance.transform.position, mouseWorldPos) < interactDistance)
                {
                    currentInteractable = hit.collider.GetComponent<IInteractable>();
                    if (currentInteractable != null)
                    {
                        currentInteractable.Pressed();
                    }
                }
                else
                {
                    Debug.Log("item too far");
                }
            }
            else
            {
                if (DogMovement.instance != null)
                    DogMovement.instance.WalkTo(mouseWorldPos);
            }

        }

        if (Input.GetMouseButtonUp(0) && currentInteractable != null)
        {
            currentInteractable.Released();
            currentInteractable = null;
        }
    }
}
