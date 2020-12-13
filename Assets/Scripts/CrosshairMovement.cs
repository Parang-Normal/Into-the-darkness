using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    //How fast should the crosshair move?
    public float Sensitivity = 500f;

    public Transform outerCircle;
    public Transform innerCircle;

    //Starting position
    private Vector2 StartPos;

    //Ending position
    private Vector2 EndPos;

    //Tracked Finger
    private Touch TrackedFinger;

    //Check if moving
    private bool isMoving = false;

    private void Update()
    { 
        
        if(Input.touchCount > 0)
        {
            TrackedFinger = Input.GetTouch(0);

            switch (TrackedFinger.phase)
            {
                case TouchPhase.Began:
                    isMoving = false;
                    StartPos = TrackedFinger.position;
                    break;

                case TouchPhase.Moved:
                    isMoving = true;
                    EndPos = TrackedFinger.position;
                    break;

                case TouchPhase.Ended:
                    isMoving = false;
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Canceled:
                    break;
            }
            
        }
        

        /*
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

        }

        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            EndPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            isMoving = false;
        }
        */
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 Diff = EndPos - StartPos;
            Vector2 Dir = Vector2.ClampMagnitude(Diff, 1f);

            //Dir *= -1;
            transform.Translate(Dir * Sensitivity * Time.deltaTime);
        }
    }
}
