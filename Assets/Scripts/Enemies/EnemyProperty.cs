using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyProperty
{
    [Tooltip("The type of Enemy")]
    public EnemyType Type;

    [Tooltip("Enemy can only be killed by this weapon")]
    public WeaponType Weakness;

    public float Health = 0.0f;
    public float MovementSpeed = 0.0f;
    public float Damage = 0.0f;
    public int Points = 0;
    public int Coins = 0;
}
