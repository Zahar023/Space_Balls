using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FreazeRotation : MonoBehaviour
{
    [SerializeField] private Transform _child;
    private void Update()
    {
        _child.transform.rotation = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z * -1.0f);
    }
}
