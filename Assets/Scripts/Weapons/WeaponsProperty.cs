using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponsProperty
{
    [Tooltip("The type of Gun")]
    public WeaponType Type;

    [Tooltip("Amount of damage it will deal per bullet")]
    public float Damage = 0f;

    [Tooltip("How large is the magazine size")]
    public int MagazineCount = 0;
}
