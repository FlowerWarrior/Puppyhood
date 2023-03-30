using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject radioUI;

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.TuneTheRadio)
            Instantiate(radioUI);
    }

    public void Pressed()
    {

    }
}
