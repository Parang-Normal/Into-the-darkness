using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMechanics : MonoBehaviour
{
    public GameObject WaveManager;
    public string MainMenuScene;
    public string UpgradeShopScene;

    void Update()
    {
        float PlayerHealth = PlayerPrefs.GetFloat("Health", 100f);

        if(PlayerHealth <= 0)
        {
            Defeat();
        }

        if(!WaveManager.activeSelf)
        {
            Victory();
        }
    }

    private void Defeat()
    {
        PlayerPrefs.SetFloat("Health", 100f);
        SceneManager.LoadScene(MainMenuScene);
    }

    private void Victory()
    {
        PlayerPrefs.SetFloat("Health", 100);
        SceneManager.LoadScene(UpgradeShopScene);
    }
}
