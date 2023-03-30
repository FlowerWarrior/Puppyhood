using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIpanel : MonoBehaviour
{
    public void Start()
    {
        ClickManager.instance.isUIPanelOpened = true;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
        ClickManager.instance.isUIPanelOpened = false;
    }
}
