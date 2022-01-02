using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace PlayerHealth {
public class PlayerHealthController : MonoBehaviour
{
public Text healthBox;
public static int health;
public static int maxHealth = 3;
public static int maxHearts;
private static float nextDmgTick;
public MenuHandler menuHandler;

[SerializeField] private static float dmgTick = 1f;

public Image[] hearts;
public Sprite heartFilled;
public Sprite hearthEmpty;


    void Start()    
    {
       health = maxHealth;
       maxHearts = hearts.Length;
    }

    void Update()
    {
        HealthbarHandle();

        if (health <= 0)
        {
            menuHandler.MenuLoseGame();
            Debug.Log("END GAME");
        }
    }

    public void HealthbarHandle() 
    {
        healthBox.text = "Health:" + health + "/" + maxHealth; //bruges kun til test
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < maxHealth)
             {
                hearts[i].enabled = true;
             }
             else
             {
                hearts[i].enabled = false;
             }

             if (i < health)
             {
                hearts[i].sprite = heartFilled;
             } 
             else 
             {
                hearts[i].sprite = hearthEmpty;
             }
        }
    }
    public static void PlayerTakeDamage(int dmg){
        health = health - dmg;
    }
    public static void PlayerHeal(int heal){
        health = health + heal;
        if (health >= maxHealth)
        health = maxHealth;
    }
    public static void PlayerGainMaxHealth() {
        if (maxHealth < maxHearts)
        maxHealth = maxHealth + 1;
    }

    public static void DamageTick(int tickDmg) {
        if (Time.time > nextDmgTick) {
            PlayerTakeDamage(tickDmg);
            nextDmgTick = Time.time + dmgTick;
        }
    }
}
}
