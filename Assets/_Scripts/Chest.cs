using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject chestUI;
    [SerializeField] Sprite chestUnlockedSprite;
    [SerializeField] GameObject collectiblePart;

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.UnlockChest)
        {
            Instantiate(chestUI);
        }
    }
        
    public void Pressed()
    {

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
        if (newTask == task.UnlockChest)
        {
            GetComponent<Animation>().Play();
        }
        else if (completedTask == task.UnlockChest)
        {
            GetComponent<SpriteRenderer>().sprite = chestUnlockedSprite;
            Instantiate(collectiblePart, transform.GetChild(0).position, Quaternion.identity, transform);
        }
    }
}