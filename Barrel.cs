using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] lootTable;
    private float randomFloat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TEst");
        if (other.gameObject.tag == "PlayerProjectile")
        {
            var rotation = new Quaternion();
            var position = new Vector3(0, 0, 0);
            var realPosition = position + transform.position;
            Destroy(gameObject);

        float randomFloat = Random.Range(0f, 100f);
        print(randomFloat); //Er der kun for test

        if(randomFloat <= 15) {                                  //Weapon 1 15%
            Instantiate(lootTable[0], realPosition, rotation);
        } else if (randomFloat <= 30 && randomFloat >= 15) {     //Weapon 1 15%
            Instantiate(lootTable[1], realPosition, rotation);
        } else if (randomFloat <= 40 && randomFloat >= 30) {     //Coin_10 10%
            Instantiate(lootTable[2], realPosition, rotation);
        } else if (randomFloat <= 60 && randomFloat >= 40) {    //Coin_5 20%
            Instantiate(lootTable[3], realPosition, rotation);
        } else if (randomFloat <= 100 && randomFloat >= 60) {    //Coin_1 40%
            Instantiate(lootTable[3], realPosition, rotation);
        }
        }

    }
}

