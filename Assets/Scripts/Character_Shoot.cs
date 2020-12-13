using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        if(touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Debug.Log($"FingerState: {t.phase.ToString()}");

            switch (t.phase)
            {
                case TouchPhase.Began:
                    break;

                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Moved:
                    break;

                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    break;
            }
        }
    }
}
