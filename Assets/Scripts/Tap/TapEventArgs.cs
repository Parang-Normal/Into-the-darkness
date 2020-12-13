using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TapEventArgs : EventArgs
{
    private Vector2 tapPos;
    private GameObject hitObject;

    public TapEventArgs(Vector2 pos, GameObject hit)
    {
        tapPos = pos;
        hitObject = hit;
    }

    public Vector2 TapPosition
    {
        get
        {
            return tapPos;
        }
    }

    public GameObject HitObject
    {
        get
        {
            return hitObject;
        }
    }
}
