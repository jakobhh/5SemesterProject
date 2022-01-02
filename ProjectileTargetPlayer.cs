using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerHealth.PlayerHealthController;

public class ProjectileTargetPlayer : MonoBehaviour
{

    public bool trackPlayer = false;
    public bool stopAtPlayerPos = false;
    public float speed;

    public float projectileLifeTime;
    private Transform player;
    private Vector2 playerPosCur;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        playerPosCur = new Vector2 (player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopAtPlayerPos == false && trackPlayer == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //Follow player movement
            Destroy(gameObject, projectileLifeTime);
        } 
        else if (stopAtPlayerPos == true && trackPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosCur, speed * Time.deltaTime); //Stops when at the location player was at when fired.
            if (transform.position.x == playerPosCur.x && transform.position.y == playerPosCur.y)
            {
                Instantiate (explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else if (stopAtPlayerPos == false && trackPlayer == false)
        {
            //add projectile that moves towards player but disapears after projectileLifeTime
        }
        else if (stopAtPlayerPos == true && trackPlayer == true)
        {
            Debug.Log("The Projectile can not both: Track player, & Stop at player pos");
            Destroy(gameObject);
        }   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    if (collision.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            PlayerTakeDamage(1);
        }
    }
}