using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCandles : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject candlesUI;

    public void Released()
    {
        if (TaskManager.instance.GetCurrentTask() == task.DoCandlesPuzzle)
            Instantiate(candlesUI);
    }

    public void Pressed()
    {

    }
}
