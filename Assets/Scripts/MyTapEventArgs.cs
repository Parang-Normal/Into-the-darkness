using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MyTapEventArgs : EventArgs
{
    private Vector2 _tapPosition;
    private GameObject _hitObject;

    public MyTapEventArgs(Vector2 pos, GameObject obj = null)
    {
        _tapPosition = pos;
        _hitObject = obj;
    }

    public Vector2 TapPosition
    {
        get
        {
            return _tapPosition;
        }
    }

    public GameObject HitObject
    {
        get
        {
            return _hitObject;
        }
    }
}
