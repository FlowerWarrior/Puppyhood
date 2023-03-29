using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] RectTransform cursorRT;
    [SerializeField] Image cursorNormal;
    [SerializeField] Image cursorHeld;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorRT.position = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            cursorNormal.gameObject.SetActive(false);
            cursorHeld.gameObject.SetActive(true);
        }
        else
        {
            cursorNormal.gameObject.SetActive(true);
            cursorHeld.gameObject.SetActive(false);
        }
    }
}
