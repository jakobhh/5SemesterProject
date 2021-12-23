using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerHealth.PlayerHealthController;

public class CollisionWithPowerup : MonoBehaviour
{
    public int gameScore;
    public Text scoreBox;
    void Update() {
        scoreBox.text = "Score: " + gameScore;
    }
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag =="Coin_1")
        {
            gameScore += 1;
            Destroy(obj.collider.gameObject);
        }

        if (obj.gameObject.tag =="Coin_5")
        {
            gameScore += 5;
            Destroy(obj.collider.gameObject);
        }

        if (obj.gameObject.tag =="Coin_10")
        {
            gameScore += 10;
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag =="Heal")
        {
            PlayerHeal(1);
            Destroy(obj.collider.gameObject);
        }
        if (obj.gameObject.tag =="GainMaxHealth")
        {
            PlayerGainMaxHealth();
            PlayerHeal(1);
            Destroy(obj.collider.gameObject);
        }

    }
}
