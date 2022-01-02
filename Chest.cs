using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject openChest;

    public GameObject[] lootTable;
    private float randomFloat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerProjectile")
        {
            var rotation = new Quaternion();
            var position = new Vector3(0, 0, 0);
            var realPosition = position + transform.position;
            Instantiate(openChest, realPosition, rotation);
            Destroy(gameObject);

        float randomFloat = Random.Range(0f, 100f);

        if(randomFloat <= 5) {                                  //Extra Heart 5%
            Instantiate(lootTable[0], realPosition, rotation);
        } else if (randomFloat <= 50 && randomFloat >= 5) {     //Potion_Heal 45%
            Instantiate(lootTable[1], realPosition, rotation);
        } else if (randomFloat <= 75 && randomFloat >= 50) {     //Potion_Speed 25%
            Instantiate(lootTable[2], realPosition, rotation);
        } else if (randomFloat <= 100 && randomFloat >= 75) {    //Potion_WeaponSpeed 25%
            Instantiate(lootTable[3], realPosition, rotation);
        }
        }

    }
}

