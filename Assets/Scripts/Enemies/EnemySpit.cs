using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpit : MonoBehaviour, IDragged
{
    private float num = 0;
    private Image img;
    private Color origColor;

    public void OnDrag(DragEventArgs args)
    {
        num--;
        //Debug.Log(num);

        if(img != null)
        {
            Color temp = origColor;
            temp.a = 1 + (num / 100);
            img.color = temp;
        }
    }

    private void Start()
    {
        img = transform.GetComponent<Image>();
        origColor = img.color;
    }
}
