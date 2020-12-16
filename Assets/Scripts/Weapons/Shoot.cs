using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    PISTOL,
    MACHINEGUN,
    SHOTGUN
}

public class Shoot : MonoBehaviour
{
    public WeaponsProperty stats;
    public Transform Crosshair = null;
    public ParticleSystem MuzzleFlash = null;
    public GameObject ImpactEffect = null;
    public float ShakeSensitivity = 5f;

    public int CurrentMag;

    private Vector3 ShakeDir;

    private void Update()
    {
        ShakeDir = Input.acceleration;

        if(ShakeDir.sqrMagnitude >= ShakeSensitivity)
        {
            Reload();
            Debug.Log("Reloaded!");
        }

    }

    private void OnValidate()
    {
        switch (stats.Type)
        {
            case WeaponType.PISTOL:
                stats.Damage = 2f + PlayerPrefs.GetFloat("Pistol_Amp", 0);
                stats.MagazineCount = 16;
                break;

            case WeaponType.MACHINEGUN:
                stats.Damage = 1f + PlayerPrefs.GetFloat("MachineGun_Amp", 0);
                stats.MagazineCount = 30;
                break;

            case WeaponType.SHOTGUN:
                stats.Damage = 10f + PlayerPrefs.GetFloat("Shotgun_Amp", 0);
                stats.MagazineCount = 5;
                break;

        }

        CurrentMag = stats.MagazineCount;
    }

    public void shoot()
    {
        if (gameObject.activeSelf)
        {
            if (CurrentMag > 0)
            {
                MuzzleFlash.Play();
                CurrentMag--;

                RaycastHit hit = new RaycastHit();

                Ray r = Camera.main.ScreenPointToRay(Crosshair.position);

                if (Physics.Raycast(r, out hit, Mathf.Infinity))
                {
                    Debug.Log(hit.transform.name);

                    EnemyStats enemyStats = hit.transform.GetComponent<EnemyStats>();
                    if (enemyStats != null)
                    {
                        enemyStats.IsHit(stats.Type, stats.Damage);
                    }

                    GameObject effect = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                    Destroy(effect, 2.0f);
                }
            }
            else
            {
                Debug.Log("No more bullets! Reload!");
            }
        }
    }

    private void Reload()
    {
        if (gameObject.activeSelf)
        {
            if (CurrentMag != stats.MagazineCount)
            {
                CurrentMag = stats.MagazineCount;
            }
            else
            {
                Debug.Log("Magazine still full!");
            }
        }
    }
}
