using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public void Pause()
    {
        UnityEngine.Time.timeScale = 0f;
    }

    public void Resume()
    {
        UnityEngine.Time.timeScale = 1f;
    }
}
