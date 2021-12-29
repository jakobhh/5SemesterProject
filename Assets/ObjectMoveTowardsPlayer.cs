using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveTowardsPlayer : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private float visionRange = 2f;
    [SerializeField] private float speed = 1f;

    void Start()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {

            if (Vector2.Distance(playerPos.position, transform.position) < visionRange) 
            {
                MoveTowardsPlayer();
            }
    }

    public void MoveTowardsPlayer() 
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, speed * Time.deltaTime);
    }
}
