using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    BERSERKER,
    CHASER,
    STINGER,
    ABOMINATION,
    CRAB_LURKER,
    MUTANT_ZOMBIE
}

enum Direction
{
    Left,
    Right
}

public class EnemyStats : MonoBehaviour
{
    public EnemyProperty stats;
    public float AttackDistance = 5f;
    public float TurnSpeed = 5f;
    public float AttackInterval = 1.5f;

    private Animator anim;
    private Transform target;
    private float interval = 0f;

    // Start is called before the first frame update
    private void OnValidate()
    {
        switch (stats.Type)
        {
            case EnemyType.CHASER:
                stats.Weakness = WeaponType.PISTOL;
                stats.Health = 10f;
                stats.MovementSpeed = 30f;
                stats.Damage = 10f;
                stats.Coins = 2;
                break;

            case EnemyType.STINGER:
                stats.Weakness = WeaponType.MACHINEGUN;
                stats.Health = 15;
                stats.MovementSpeed = 15f;
                stats.Damage = 15f;
                stats.Coins = 3;
                break;

            case EnemyType.BERSERKER:
                stats.Weakness = WeaponType.SHOTGUN;
                stats.Health = 30f;
                stats.MovementSpeed = 10f;
                stats.Damage = 20f;
                stats.Coins = 5;
                break;

            case EnemyType.ABOMINATION:
                stats.Weakness = WeaponType.PISTOL;
                stats.Health = 40f;
                stats.MovementSpeed = 10f;
                stats.Damage = 20f;
                stats.Coins = 20;
                break;

            case EnemyType.CRAB_LURKER:
                stats.Weakness = WeaponType.MACHINEGUN;
                stats.Health = 50f;
                stats.MovementSpeed = 10f;
                stats.Damage = 20f;
                stats.Coins = 30;
                break;

            case EnemyType.MUTANT_ZOMBIE:
                stats.Weakness = WeaponType.SHOTGUN;
                stats.Health = 60f;
                stats.MovementSpeed = 10f;
                stats.Damage = 20f;
                stats.Coins = 50;
                break;
        }

        stats.Points = stats.Coins * 10;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        FaceTarget();

        if (distance <= AttackDistance)
        {
            anim.SetBool("Attack", true);
            if(Time.time > interval)
            {
                interval = Time.time + AttackInterval;
                float health = PlayerPrefs.GetFloat("Health", 100f);
                health -= stats.Damage;
                PlayerPrefs.SetFloat("Health", health);
                Debug.Log("Damaged!");
            }
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * TurnSpeed);
    }

    public void IsHit(WeaponType weapon, float damage)
    {
        if(stats.Weakness == weapon)
        {
            stats.Health -= damage;
            Debug.Log(stats.Health);

            if(stats.Health <= 0)
            {
                anim.SetBool("IsDead", true);
                //Destroy(this.gameObject);
                transform.GetComponent<Collider>().enabled = false;

                int score = PlayerPrefs.GetInt("Score", 0);
                score += stats.Points;
                PlayerPrefs.SetInt("Score", score);

                int coins = PlayerPrefs.GetInt("Coins", 0);
                coins += stats.Coins;
                PlayerPrefs.SetInt("Coins", coins);

                Destroy(gameObject, 5f);
                transform.GetComponent<EnemyStats>().enabled = false;
            }
        }
    }

    public void SetTarget(Transform player)
    {
        target = player;
    }
}
