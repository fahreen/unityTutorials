using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController playerControllerScript; //for script communication, declare variable
    // Start is called before the first frame update
    private float leftBound = -15;
    void Start()
    {
        //get player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(playerControllerScript.gameOver == false)
        {
            if (this.gameObject.CompareTag("Enemy"))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);

            }
        }


        if(this.transform.position.x < leftBound && this.gameObject.CompareTag("Obstacle") )
        {
            Destroy(this.gameObject);
        }
    }
}
