using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public float speed = 1f;
    void FixedUpdate()
    { 

    // Player movement X & Z.
   float h = Input.GetAxis("Horizontal");
   float v = Input.GetAxis("Vertical");
   gameObject.transform.position = new Vector2 (transform.position.x + (h * speed), transform.position.y + (v * speed));
    }
}
