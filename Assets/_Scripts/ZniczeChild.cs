using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZniczeChild : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Click); //subscribe to the onClick event

    }

    void Click()
    {
        Debug.Log("cliked");
        if (Znicze.CheckCandle(gameObject)==true)
        {
            Znicze.ChangeTexture(gameObject);
        }
    }
}
