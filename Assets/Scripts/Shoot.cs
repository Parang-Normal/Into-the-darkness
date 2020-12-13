using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform Crosshair = null;

    private Vector2 loc;

    public void shoot()
    {
        RaycastHit hit = new RaycastHit();

        Ray r = Camera.main.ScreenPointToRay(Crosshair.position);
        
        if (Physics.Raycast(r, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
