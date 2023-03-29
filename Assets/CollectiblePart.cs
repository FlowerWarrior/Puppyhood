using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePart : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject particlesPrefab;

    public void Pressed()
    {

    }

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.CollectDogPart)
        {
            TaskManager.instance.SetTaskCompleted(task.CollectDogPart);
            Destroy(gameObject);
            GameObject particles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);
            Destroy(particles, 4);
        }   
    }
}
