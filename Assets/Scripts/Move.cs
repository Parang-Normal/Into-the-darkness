using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, ITapped, ISwipped, IDragged
{
    public Vector3 TargetPosition = Vector3.zero;
    private float DefaultSpeed = 10f;

    public void OnEnable()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, DefaultSpeed * Time.deltaTime);
    }

    public void OnTap(TapEventArgs args)
    {
        if (args.HitObject == gameObject)
        {
            Debug.Log($"Hit: {args.HitObject.name}");
            //Destroy(args.HitObject);
        }
        else if(args.HitObject == null)
        {
            Ray r = Camera.main.ScreenPointToRay(args.TapPosition);
            Spawn(r.GetPoint(10));
        }
    }

    public void OnSwipe(SwipeEventArgs args)
    {
        Vector3 dir = Vector3.zero;

        /*
        switch (args.SwipeDirection)
        {
            case SwipeDirections.UP: dir.y = 1; break;
            case SwipeDirections.DOWN: dir.y = -1; break;
            case SwipeDirections.RIGHT: dir.x = 1; break;
            case SwipeDirections.LEFT: dir.x = -1; break;
        }
        */

        dir = (Vector3)args.SwipeVector.normalized;

        TargetPosition += (dir * 5);
    }

    public void OnDrag(DragEventArgs args)
    {   
        float pitch = Camera.main.transform.rotation.x;

        if (args.HitObject == gameObject)
        {
            //Convert the screen position of the finger to world point
            Ray r = Camera.main.ScreenPointToRay(args.TargetFinger.position);
            Vector3 worldPoint = r.GetPoint(10  );

            TargetPosition = worldPoint;
            transform.position = worldPoint;
        }

        //Camera.main.transform.eulerAngles = new Vector3(args.TargetFinger.position.x, args.TargetFinger.position.y, 0f);
    }

    private void Spawn(Vector2 pos)
    {
        Instantiate(this.transform.GetComponentInParent<GameObject>(), pos, Quaternion.identity);
    }
}
