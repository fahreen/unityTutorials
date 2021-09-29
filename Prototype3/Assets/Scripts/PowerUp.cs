using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(fly(other));
        }
    }



    //coroutine
    IEnumerator fly(Collider player)
    {

        player.transform.localScale *= 1.4f;

        //make immune to enemies
        player.tag = "PlayerPowerup";

        PlayerController playerScript = player.GetComponent<PlayerController>();

        playerScript.bgMusic.Stop();
        playerScript.powerupMusic.Play();

        //disable powerup graphics
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        //gain a extra health
        playerScript.health++;
        //playerScript.healthCounterText.text = "INFINITY";

        //wait
        yield return new WaitForSeconds(7);

        player.transform.localScale /= 1.4f;
        player.tag = "Player";
        playerScript.bgMusic.Play();
        playerScript.powerupMusic.Stop();


        Debug.Log("POWERUP");
        //remove powerup
        Destroy(gameObject);

    }
}
