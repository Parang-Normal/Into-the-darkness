using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public delegate void EnemyKilled();

    public static event EnemyKilled OnEnemyKilled;

    public Animator CamAnim;

    private int waveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (waveIndex < transform.childCount)
        {
            GameObject child = transform.GetChild(waveIndex).gameObject;
            if (child.activeSelf)
            {
                if (child.GetComponent<EnemySpawner>().IsFinished())
                {
                    child.SetActive(false);
                    waveIndex++;

                    if (waveIndex < transform.childCount)
                    {
                        transform.GetChild(waveIndex).gameObject.SetActive(true);
                        CamAnim.SetInteger("Sequence", waveIndex);
                    }
                }
            }
        }

        if(waveIndex == transform.childCount)
        {
            gameObject.SetActive(false);
        }
    }

    public void die()
    {
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }
    }
}
