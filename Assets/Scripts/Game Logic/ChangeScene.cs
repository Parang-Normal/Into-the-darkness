using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public bool OnWake = false;

    private void OnEnable()
    {
        if (OnWake)
        {
            Change();
        }
    }

    public void Change()
    {
        SceneManager.LoadScene(SceneName);
    }
}
