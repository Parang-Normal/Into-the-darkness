using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void EnemyKilled();

    public static event EnemyKilled OnEnemyKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
