using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapReceiver : MonoBehaviour
{
    public GameObject spawn;

    private void Start()
    {
        //Register this class' OnTap to the Gesture Manager
        GestureManager.Instance.OnTap += OnTap;
    }

    private void OnDisable()
    {
        //Remove this class' OnTap in case this gets destroyed
        GestureManager.Instance.OnTap -= OnTap;
    }

    private void OnTap(object sender, TapEventArgs e)
    {
        if(e.HitObject == null)
        {
            Ray r = Camera.main.ScreenPointToRay(e.TapPosition);
            Spawn(r.GetPoint(10));
        }
        else
        {
            Debug.Log($"Hit: {e.HitObject.name}");
        }

    }

    private void Spawn(Vector2 pos)
    {
        Instantiate(spawn, pos, Quaternion.identity);
    }
}
