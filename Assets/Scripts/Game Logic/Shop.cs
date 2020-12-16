using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private WeaponType Type;
    private float DamageAmp;
    private int Cost;

    public void Upgrade()
    {
        float CurrentAmp;
        int CurrentCoins = PlayerPrefs.GetInt("Coins", 0);

        if (CurrentCoins - Cost >= 0)
        {
            if (Type == WeaponType.PISTOL)
            {
                CurrentAmp = PlayerPrefs.GetFloat("Pistol_Amp", 0f);
                CurrentAmp += DamageAmp;
                PlayerPrefs.SetFloat("Pistol_Amp", CurrentAmp);
            }

            else if (Type == WeaponType.MACHINEGUN)
            {
                CurrentAmp = PlayerPrefs.GetFloat("MachineGun_Amp", 0);
                CurrentAmp += DamageAmp;
                PlayerPrefs.SetFloat("MachineGun_Amp", CurrentAmp);
            }

            else if (Type == WeaponType.SHOTGUN)
            {
                CurrentAmp = PlayerPrefs.GetFloat("Shotgun_Amp", 0);
                CurrentAmp += DamageAmp;
                PlayerPrefs.SetFloat("Shotgun_Amp", CurrentAmp);
            }

            CurrentCoins -= Cost;
            PlayerPrefs.SetInt("Coins", CurrentCoins);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    public void setType(string t)
    {
        switch (t)
        {
            case "Pistol":
                Type = WeaponType.PISTOL;
                break;

            case "MachineGun":
                Type = WeaponType.MACHINEGUN;
                break;

            case "Shotgun":
                Type = WeaponType.SHOTGUN;
                break;

            default:
                Debug.Log("Error weapon type");
                break;
        }
    }

    public void setAmp(float a)
    {
        DamageAmp = a;
    }

    public void setCost(int c)
    {
        Cost = c;
    }
}
