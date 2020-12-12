using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;

    public event EventHandler<MyTapEventArgs> OnTap;

    public TapProperty _tapProperty;

    //Point where gesture started
    private Vector2 startPoint = Vector2.zero;
    //Point where gesture ended
    private Vector2 endPoint = Vector2.zero;
    //Time from Began to Ended
    private float gestureTime = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    Touch trackedFinger1;

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            trackedFinger1 = Input.GetTouch(0);
            
            if(trackedFinger1.phase == TouchPhase.Began)
            {
                startPoint = trackedFinger1.position;
                gestureTime = 0;
            }

            if(trackedFinger1.phase == TouchPhase.Ended)
            {
                endPoint = trackedFinger1.position;

                //If total gesture time is below max AND if covered screen distance is below max
                if(gestureTime <= _tapProperty.tapTime && Vector2.Distance(startPoint, endPoint) < (Screen.dpi * _tapProperty.tapMaxDistance))
                {
                    FireTapEvent(startPoint);
                }
            }
            else
            {
                gestureTime += Time.deltaTime;
            }
        }
    }

    private void FireTapEvent(Vector2 pos)
    {
        Debug.Log("TAP!");
        if(OnTap != null)
        {
            Ray r = Camera.main.ScreenPointToRay(pos);
            RaycastHit h = new RaycastHit();
            GameObject hitObj = null;

            if(Physics.Raycast(r, out h, Mathf.Infinity))
            {
                hitObj = h.collider.gameObject;
            }

            //Create the event args first
            MyTapEventArgs tapArgs = new MyTapEventArgs(pos, hitObj);

            //On Tap with THIS as the sender + tapArgs
            OnTap(this, tapArgs);
        }
    }

    private void OnDrawGizmos()
    {
        if(Input.touchCount > 0)
        {
            Ray r = Camera.main.ScreenPointToRay(trackedFinger1.position);
            Gizmos.DrawIcon(r.GetPoint(5), "Target");
        }
    }
}
