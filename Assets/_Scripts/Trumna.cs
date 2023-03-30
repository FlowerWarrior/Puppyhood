using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumna : MonoBehaviour, IInteractable
{
    [SerializeField] Sprite trumnaUnlockedSprite;
    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.ClickTrumna)
        {
            TaskManager.instance.SetTaskCompleted(task.ClickTrumna);
            GetComponent<SpriteRenderer>().sprite = trumnaUnlockedSprite;
        }
            
    }

    public void Pressed()
    {

    }
}
