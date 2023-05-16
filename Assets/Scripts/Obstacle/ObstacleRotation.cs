using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0,0,3.0f);
    }
}
