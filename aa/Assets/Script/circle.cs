using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    [SerializeField]
    float turnspeed;

    void Update()
    {
        transform.Rotate(0, 0, turnspeed);
    }
}
