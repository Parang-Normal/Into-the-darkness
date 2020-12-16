using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject MachineGun;
    public GameObject Shotgun;


    private int CurMag;
    private int MaxMag;

    private void Update()
    {

        if (Pistol.activeSelf)
        {
            CurMag = Pistol.transform.GetComponent<Shoot>().CurrentMag;
            MaxMag = Pistol.transform.GetComponent<Shoot>().stats.MagazineCount;
        }   
        else if (MachineGun.activeSelf)
        {
            CurMag = MachineGun.transform.GetComponent<Shoot>().CurrentMag;
            MaxMag = MachineGun.transform.GetComponent<Shoot>().stats.MagazineCount;
        }
        else if (Shotgun.activeSelf)
        {
            CurMag = Shotgun.transform.GetComponent<Shoot>().CurrentMag;
            MaxMag = Shotgun.transform.GetComponent<Shoot>().stats.MagazineCount;
        }

        transform.GetComponent<Text>().text = "Bullets: " + CurMag + "|" + MaxMag;
    }
}
