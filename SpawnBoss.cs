using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
public int statueHealth = 3;

void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="PlayerProjectile")
        {
            statueHealth--;
            Destroy(collision.gameObject);
            if (statueHealth <= 0) {
                Destroy(gameObject);
                var position = new Vector3(0, 0, 0);
                var realPosition = position + transform.position;
                var boss = GameObject.FindGameObjectWithTag("Boss");
                boss.SetActive(true);
                boss.transform.position = realPosition;
            }

        }
    }
}
