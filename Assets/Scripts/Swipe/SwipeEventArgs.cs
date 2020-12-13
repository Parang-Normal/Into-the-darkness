using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SwipeDirections
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class SwipeEventArgs : EventArgs
{
    //Position where you swiped
    private Vector2 swipePos;

    //Raw Swipe Direction
    private Vector2 swipeVector;

    //Direction of the swipe
    private SwipeDirections swipeDirection;

    //Hit Object
    private GameObject hitObject;

    public SwipeEventArgs(Vector2 pos, Vector2 v, SwipeDirections dir, GameObject hit)
    {
        swipePos = pos;
        swipeVector = v;
        swipeDirection = dir;
        hitObject = hit;
    }

    public Vector2 SwipePos
    {
        get
        {
            return swipePos;
        }
    }

    public Vector2 SwipeVector
    {
        get
        {
            return swipeVector;
        }
    }

    public SwipeDirections SwipeDirection
    {
        get
        {
            return swipeDirection;
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
