using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxineRotable : IRotable {

    public ToxineRotable(float _timeToRotate, Transform objTransf)
    {
        maxTimeToRotate = timeToRotate;
        timeToRotate = _timeToRotate;
        _transform = objTransf;
    }
}
