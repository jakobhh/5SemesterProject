using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth.PlayerHealthController;
    public class EnemyController : MonoBehaviour
{
private Transform playerPos;
[SerializeField]
private float speed;
[SerializeField]
private float visionRange; 
[SerializeField]
private float minRange; //Til meele enemy bør denne være spillerens brede, ved ranged enemy kan denne instilles så fjenden ikke går helt op til spilleren.
[SerializeField]
public int auraDamage = 1;
public float auraRange = 1;

public GameObject projectile;
public float fireRate;
private float nextShotTime = 0; 
public bool isRanged = false;
public int ScoreWorth = 5;
public int health = 3;
    void Start() 
     {
        playerPos = FindObjectOfType<PlayerController>().transform;
     }

    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) > minRange && Vector2.Distance(playerPos.position, transform.position) < visionRange)
        {
            MoveTowardsPlayer();
        }
        if (Vector2.Distance(playerPos.position, transform.position) <= auraRange)
        {
            DamageTick(auraDamage);
        }
        
        SpawnProjectile();
    }

    public void MoveTowardsPlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, speed * Time.deltaTime);
    }

    public void SpawnProjectile() 
    {
        if (isRanged) {
            if (Vector2.Distance(playerPos.position, transform.position) < visionRange && Time.time > nextShotTime) 
            {
                Instantiate (projectile, transform.position, Quaternion.identity);
                nextShotTime = Time.time + fireRate;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0) {
                CollisionWithPowerup.GainScore(ScoreWorth);
                Destroy(gameObject);
            }

        }
    }
}

