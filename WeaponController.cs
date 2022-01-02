using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponController : MonoBehaviour
{
public GameObject projectile;
public Transform spawnPoint;
public float projectileSpeed;
public float projectileLifeTime;
public float baseFireRate = 1F;
private float fireRate;
private float nextShotTime = 0; 
public static float fireRateEndTime;
public Image fireRateBoostImg;

public Text fireRateBoostTextTimer;


    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) && Time.time > nextShotTime)
            {
                nextShotTime = Time.time + fireRate;
                GameObject ball = Instantiate(projectile, spawnPoint.position, transform.rotation);
                ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2 ((projectileSpeed * 100), 0));
                Destroy(ball, projectileLifeTime);
            }
        //FireRate Booster
        if (fireRateEndTime > Time.time) 
            {
                fireRate = baseFireRate * 0.75f;
                fireRateBoostImg.enabled = true;
                fireRateBoostTextTimer.enabled = true;
                fireRateBoostTextTimer.text = (fireRateEndTime - Time.time).ToString("#.0");
            } else {
                fireRate = baseFireRate;
                fireRateBoostImg.enabled = false;
                fireRateBoostTextTimer.enabled = false;
            } 
    }
    public static void FireRateBoost(float fireRateDuration)
    {
        fireRateEndTime = fireRateDuration + Time.time;
    }
    
}
