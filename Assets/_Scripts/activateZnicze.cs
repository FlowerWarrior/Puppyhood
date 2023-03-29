using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateZnicze : MonoBehaviour
{
    [SerializeField]GameObject ZniczeCanvas;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("player"))
        {
            ZniczeCanvas.SetActive(true);
        }
    }
}
