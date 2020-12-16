using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;

    //Tap
    public TapProperty _tapProperty;
    public event EventHandler<TapEventArgs> OnTap;

    //Swipe
    public SwipeProperty _swipeProperty;
    public event EventHandler<SwipeEventArgs> OnSwipe;

    //Drag
    public DragProperty _dragProperty;
    public event EventHandler<DragEventArgs> OnDrag;

    //Point where gesture started
    private Vector2 startPoint = Vector2.zero;
    //Point where gesture ended
    private Vector2 endPoint = Vector2.zero;
    //Time from Began to Ended
    private float gestureTime = 0;

    Touch trackedFinger1;

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

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            trackedFinger1 = Input.GetTouch(0);

            switch (trackedFinger1.phase)
            {
                case TouchPhase.Began:
                    startPoint = trackedFinger1.position;
                    gestureTime = 0;
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    endPoint = trackedFinger1.position;
                    FireDragEvents();
                    gestureTime += Time.deltaTime;
                    break;

                case TouchPhase.Ended:
                    endPoint = trackedFinger1.position;


                    //If total gesture time is below max AND if covered screen distance is below max
                    if (gestureTime <= _tapProperty.tapTime && Vector2.Distance(startPoint, endPoint) < (Screen.dpi * _tapProperty.tapMaxDistance))
                    {
                        FireTapEvent();
                    }


                    //If gesture is below the max time AND if finger moved more than the minimum required
                    if (gestureTime <= _swipeProperty.SwipeTime && (Vector2.Distance(startPoint, endPoint) >= (_swipeProperty.minSwipeDistance * Screen.dpi)))
                    {
                        FireSwipeEvent();
                    }
                    break;
            }

        }
    }

    private void FireTapEvent()
    {

        Ray r = Camera.main.ScreenPointToRay(startPoint);
        RaycastHit h = new RaycastHit();
        GameObject hitObj = null;

        if(Physics.Raycast(r, out h, Mathf.Infinity))
        {
            hitObj = h.collider.gameObject;
        }

        //Create the event args first
        TapEventArgs args = new TapEventArgs(startPoint, hitObj);

        if (OnTap != null)
        {
            //On Tap with THIS as the sender + tapArgs
            OnTap(this, args);
        }

        if(hitObj != null)
        {
            ITapped tap = hitObj.GetComponent<ITapped>();
            if(tap != null)
            {
                tap.OnTap(args);
            }
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 diff = endPoint - startPoint;

        SwipeDirections swipeDir;

        RaycastHit2D hit = new RaycastHit2D();
        GameObject hitObj = null;

        if (Physics2D.Raycast(startPoint, Vector2.zero))
        {
            hit = Physics2D.Raycast(startPoint, Vector2.zero);
            hitObj = hit.collider.gameObject;
        }

        //Check which axis changed the most x or y
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            //If x is > 0 right, otherwise left
            if (diff.x > 0)
            {
                //Debug.Log("SWIPE RIGHT");
                swipeDir = SwipeDirections.RIGHT;
            }
            else
            {
                //Debug.Log("SWIPE LEFT");
                swipeDir = SwipeDirections.LEFT;
            }
        }
        else
        {
            //If y is > 0 up, otherwise down
            if (diff.y > 0)
            {
                //Debug.Log("SWIPE UP");
                swipeDir = SwipeDirections.UP;
            }
            else
            {
                //Debug.Log("SWIPE DOWN");
                swipeDir = SwipeDirections.DOWN;
            }
        }

        SwipeEventArgs args = new SwipeEventArgs(startPoint, diff, swipeDir, hitObj);

        if (OnSwipe != null)
        {
            OnSwipe(this, args);
        }

        if(hitObj != null)
        {
            ISwipped swipe = hitObj.GetComponent<ISwipped>();
            if(swipe != null)
            {
                swipe.OnSwipe(args);
            }
        }
    }

    private void FireDragEvents()
    {
        IDragged drag;

        RaycastHit2D hit = new RaycastHit2D();
        GameObject hitObj = null;
        
        if (Physics2D.Raycast(startPoint, Vector2.zero))
        {
            hit = Physics2D.Raycast(startPoint, Vector2.zero);
            hitObj = hit.collider.gameObject;
        }

        DragEventArgs args = new DragEventArgs(trackedFinger1, startPoint, endPoint, hitObj);

        if(OnDrag != null)
        {
            OnDrag(this, args);
        }

        if(hitObj != null)
        {
            drag = hitObj.GetComponent<IDragged>();
            if(drag != null)
            {
                drag.OnDrag(args);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(Input.touchCount > 0)
        {
            Ray r = Camera.main.ScreenPointToRay(trackedFinger1.position);
            Gizmos.DrawIcon(r.GetPoint(5), "Draw");
        }
    }
}
