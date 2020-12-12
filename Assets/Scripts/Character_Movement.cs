using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    [SerializeField] float Movement_Speed = 10.0f;

    private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        this.position = this.transform.GetComponent<Transform>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
    }
}
