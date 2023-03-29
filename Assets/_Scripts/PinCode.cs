using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCode : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject pinCodeUI;

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.UnlockMusicPinCode)
            Instantiate(pinCodeUI);
    }

    public void Pressed()
    {

    }
}
