using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerHealth.PlayerHealthController;

public class CollisionWithPowerup : MonoBehaviour
{
    public static int gameScore;
    public Text scoreBox;
    public Text scoreBoxEnd;

    private SwitchWeapon switchWeapon;
    void Update()
    {
        scoreBox.text = ": " + gameScore;
        scoreBoxEnd.text = "Final Score: " + gameScore;
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Coin_1")
        {
            GainScore(1);
            Destroy(obj.collider.gameObject);
        }

        if (obj.gameObject.tag == "Coin_5")
        {
            GainScore(5);
            Destroy(obj.collider.gameObject);
        }

        if (obj.gameObject.tag == "Coin_10")
        {
            GainScore(10);
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag == "Heal")
        {
            PlayerHeal(1);
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag == "GainMaxHealth")
        {
            PlayerGainMaxHealth();
            PlayerHeal(1);
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag == "SpeedBoost")
        {
            PlayerController.PlayerSpeedBoost(0.25f, 5);
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag == "FireRateBoost")
        {
            WeaponController.FireRateBoost(5f);
            Destroy(obj.collider.gameObject);
        }

    }

    public static void GainScore(int score)
    {
        gameScore += score;
    }
}
