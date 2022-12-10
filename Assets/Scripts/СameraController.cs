using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float smoothness;

    private void Update()
    {
        if(target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smoothness);
        }
    }
}
