using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth.PlayerHealthController;

public class Explosion : MonoBehaviour
{
    SphereCollider col;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SphereCollider>();

        playerPos = FindObjectOfType<PlayerController>().transform;
        Destroy(gameObject, 1);

        if (Vector2.Distance(playerPos.position, transform.position) < col.radius)
        {
            PlayerTakeDamage(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
