using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WeaponObjects
{
    public GameObject Pistol;
    public GameObject MachineGun;
    public GameObject Shotgun;
}

[System.Serializable]
public class WeaponIcons
{
    public Sprite Pistol;
    public Sprite MachineGun;
    public Sprite Shotgun;
}


public class SwitchWeapons : MonoBehaviour, ISwipped
{
    //public GameObject Pistol;
    //public GameObject MachineGun;
    //public GameObject Shotgun;
    public WeaponObjects Weapons;
    public WeaponIcons Icons;

    private int iterator = 0;
    private Image image;

    private void Start()
    {
        image = transform.GetComponent<Image>();    
    }

    public void OnSwipe(SwipeEventArgs args)
    {

        if(args.SwipeDirection == SwipeDirections.LEFT)
        {
            iterator--;
            if(iterator < 0)
            {
                iterator = 2;
            }
        }
        else if(args.SwipeDirection == SwipeDirections.RIGHT)
        {
            iterator++;
            if(iterator > 2)
            {
                iterator = 0;
            }
        }

        SwitchGun();
    }

    private void SwitchGun()
    {
        if(iterator == 0)
        {
            Weapons.Pistol.SetActive(true);
            Weapons.MachineGun.SetActive(false);
            Weapons.Shotgun.SetActive(false);

            image.sprite = Icons.Pistol;
        }
        else if(iterator == 1)
        {
            Weapons.Pistol.SetActive(false);
            Weapons.MachineGun.SetActive(true);
            Weapons.Shotgun.SetActive(false);

            image.sprite = Icons.MachineGun;
        }
        else if(iterator == 2)
        {
            Weapons.Pistol.SetActive(false);
            Weapons.MachineGun.SetActive(false);
            Weapons.Shotgun.SetActive(true);

            image.sprite = Icons.Shotgun;
        }

    }
}
