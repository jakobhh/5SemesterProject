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
public static int auraDamage = 1;
    void Start() 
     {
        playerPos = FindObjectOfType<PlayerController>().transform;
     }

    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) > minRange)
        {
            if (Vector2.Distance(playerPos.position, transform.position) < visionRange) 
            {
                MoveTowardsPlayer();
            }
        } else {

            DamageTick(auraDamage);
        }
 
    }

    public void MoveTowardsPlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, speed * Time.deltaTime);
    }
}

