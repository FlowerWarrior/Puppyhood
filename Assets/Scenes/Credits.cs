using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] float movingSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, movingSpeed, 0);
    }
}
