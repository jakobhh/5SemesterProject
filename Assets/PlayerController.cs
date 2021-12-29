using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.2f;
    public float Normalspeed = 0.2f;
    public Image speedBoostImg;

    public Text speedBoostTextTimer;
    private static float speedBoostAmount;
    private static float speedBoostEndTime;
    void FixedUpdate()
    {

        // Player movement X & Z.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gameObject.transform.position = new Vector2(transform.position.x + (h * speed), transform.position.y + (v * speed));
    }

    void Update()
    {
        speedTest();
        CollisionsToIgnore();
    }

    public static void PlayerSpeedBoost(float speedBoostValue, float speedBoostDuration)
    {
        speedBoostEndTime = speedBoostDuration + Time.time;
        speedBoostAmount = speedBoostValue;
    }
    void speedTest()
    {
        if (speedBoostEndTime > Time.time)
        {
            speed = speedBoostAmount;
            speedBoostImg.enabled = true;
            speedBoostTextTimer.enabled = true;
            speedBoostTextTimer.text = (speedBoostEndTime - Time.time).ToString("#.0");

        }
        else
        {
            speed = Normalspeed;
            speedBoostImg.enabled = false;
            speedBoostTextTimer.enabled = false;
        }
    }
    void CollisionsToIgnore()
    {
        Physics2D.IgnoreLayerCollision(6, 7); //Player and Player Projectile
        Physics2D.IgnoreLayerCollision(8, 9); //Enemy and Enemy Projectile
        Physics2D.IgnoreLayerCollision(7, 9); //Player Projectile and Enemy Projectile
    }
}
