using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollissions : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            if (this.transform.position.y < 19)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

        else if (other.CompareTag("Player"))
        {
            Debug.Log("DEAD");
           // PlayerController playerScript = other.GetComponent<PlayerController>();
           // playerScript.health--;
            //Debug.Log(playerScript.health);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
             playerScript.health--;
            Debug.Log(playerScript.health);
            if (playerScript.health < 0)
            {
                Debug.Log("Game over!");
            }
        }

    }
}
