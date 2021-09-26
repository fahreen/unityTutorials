using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 6, 1);

        float scale = Random.Range(1.0f, 20.0f);
        transform.localScale = Vector3.one * scale;
        
        Material material = Renderer.material;
        
        material.color = new Color(1,0,1,1);
    }
    
    void Update()
    {

        transform.Rotate(-10.0f * Time.deltaTime*20, 0.0f, 0.0f);
    }
}
