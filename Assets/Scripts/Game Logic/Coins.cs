using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    void Update()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);

        transform.GetComponent<Text>().text = "Coins: " + coins;
    }
}
