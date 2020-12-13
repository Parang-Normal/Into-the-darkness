using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour, IDragged
{
    public float RotateSpeed = 100f;

    private float pitch = 0f;
    private float yaw = 0f;

    public void OnDrag(DragEventArgs args)
    {
        pitch -= args.TargetFinger.deltaPosition.y * RotateSpeed * Time.deltaTime;
        yaw += args.TargetFinger.deltaPosition.x * RotateSpeed * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, -60f, 60f);
        yaw = Mathf.Clamp(yaw, -60f, 60f);

        this.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
