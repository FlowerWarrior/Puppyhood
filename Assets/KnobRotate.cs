using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnobRotate : MonoBehaviour
{
    public Transform rotator;
    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = rotator.rotation.eulerAngles.z;
        rectTransform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}