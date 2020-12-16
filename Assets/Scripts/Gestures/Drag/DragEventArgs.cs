using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragEventArgs : EventArgs
{
    //Current state of the finger
    private Touch targetFinger;

    //Starting Position
    private Vector2 startPoint;

    //Ending Position
    private Vector2 endPoint;

    //Hit object
    private GameObject hitobject;

    public DragEventArgs(Touch finger, Vector2 start, Vector2 end, GameObject hit)
    {
        targetFinger = finger;
        startPoint = start;
        endPoint = end;
        hitobject = hit;
    }

    public Touch TargetFinger
    {
        get
        {
            return targetFinger;
        }
    }

    public Vector2 StartPoint
    {
        get
        {
            return startPoint;
        }
    }

    public Vector2 EndPoint
    {
        get
        {
            return endPoint;
        }
    }

    public GameObject HitObject
    {
        get
        {
            return hitobject;
        }
    }
}
