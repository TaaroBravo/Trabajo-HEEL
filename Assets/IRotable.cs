using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class IRotable
{
    public float maxTimeToRotate;
    public float timeToRotate;
    public Transform _transform;

    public void Update()
    {
        timeToRotate -= Time.deltaTime;
        if (timeToRotate < 0)
        {
            _transform.Rotate(0, 0, 1);
            timeToRotate = maxTimeToRotate;
        }
    }
}
