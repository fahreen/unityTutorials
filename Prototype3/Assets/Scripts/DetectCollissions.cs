using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollissions : MonoBehaviour
{
    public AudioClip enemySound;
    public AudioSource playerAudio;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo")  && this.transform.position.y < 19)
        {
                Destroy(gameObject);
                Destroy(other.gameObject);
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
             playerScript.health--;
            Debug.Log(playerScript.health);
            playerAudio.PlayOneShot(enemySound, 1.0f) ;


          
        }

    }
}
