using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public Material powerupMaterial;

    // Start is called before the first frame update

    private void Start()
    {
       // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          StartCoroutine( fly(other));
        }
    }



    //coroutine
    IEnumerator fly(Collider player)
    {

        player.transform.localScale *= 1.4f;
        Physics.gravity *= 0.3f;



        // PlayerController playerControllerScript = player.GetComponent<PlayerController>();

        //Physics.gravity = 
        //player.transform.localPosition.Set(player.transform.position.x, player.transform.position.y + 4, player.transform.position.z);
        //playerControllerScript.gravityModifier = 0.3f;
        //Physics.gravity *= 0.3f;

        //disable powerup graphics
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

      
   
        //wait
        yield return new WaitForSeconds(3);

        player.transform.localScale /= 1.4f;
        Physics.gravity /= 0.3f;
        Debug.Log("POWERUP");
        //remove powerup
        Destroy(gameObject);

    }
}
