using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMovement : MonoBehaviour, IDragged
{
    //How fast should the crosshair move?
    public float Sensitivity = 500f;

    public Transform outerCircle;
    public Transform innerCircle;
    public Transform Crosshair;
    public float ScreenOffset = 50f;

    //Original Position of the button
    private Vector2 origPos;

    //Radius of the Crosshair
    private float radius = 100f;
    private float width;
    private float height;

    public void OnDrag(DragEventArgs args)
    {
        innerCircle.transform.position = Vector2.zero;

        //Distance between point A and point B then clamp max distance
        Vector2 Diff = args.EndPoint - args.StartPoint;
        Vector2 Dir = Vector2.ClampMagnitude(Diff, 50.0f);

        innerCircle.transform.position = new Vector2(origPos.x + Dir.x, origPos.y + Dir.y);

        //Clamps the crosshair so it will stay within the screen
        Vector3 ClampPos = Crosshair.position;
        ClampPos.x = Mathf.Clamp(ClampPos.x, 0 + radius, Screen.width - radius);
        ClampPos.y = Mathf.Clamp(ClampPos.y, 0 + radius, Screen.height - radius);
        Crosshair.position = ClampPos;

        Crosshair.Translate(Dir * Sensitivity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        //Ray2D r = new Ray2D(Crosshair.position, new Vector2(0, ScreenOffset));

        Vector3 newLoc = Crosshair.position;
        newLoc.y += radius;
        Gizmos.DrawLine(Crosshair.position, newLoc);
    }

    private void Start()
    {
        origPos = new Vector2(innerCircle.transform.position.x, innerCircle.transform.position.y);
        width = Crosshair.GetComponentInParent<Image>().sprite.border.x / 2;
        height = Crosshair.GetComponentInParent<Image>().sprite.border.y / 2;
    }
}
