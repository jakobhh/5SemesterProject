using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
public GameObject projectile;
public Transform spawnPoint;
public float projectileSpeed;
public float projectileLifeTime;
public float fireRate = 1F;   
public float nextShotTime = 0; 

    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && Time.time > nextShotTime)
            {
                nextShotTime = Time.time + fireRate;
                GameObject ball = Instantiate(projectile, spawnPoint.position, transform.rotation);
                ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector2 (projectileSpeed, 0));
                Destroy(ball, projectileLifeTime);
            }
    }
    
}
