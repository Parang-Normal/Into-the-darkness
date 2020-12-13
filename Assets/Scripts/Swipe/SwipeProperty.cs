using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwipeProperty
{
    [Tooltip("Minimun Distance covered to be considered a swipe")]
    public float minSwipeDistance = 2f;
    [Tooltip("Maximum gesture time until its not a swipe anymore")]
    public float SwipeTime = 0.7f;
}
