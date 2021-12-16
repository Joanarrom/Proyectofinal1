using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    private float speed = 30f;
    private float destroyTime = 5f;

    void Start()
    {
     Destroy(gameObject, destroyTime);
    }      
    void Update()
    {        
     transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void OnCollisionEnter(Collision otherCollider)
    {       
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
         Destroy(otherCollider.gameObject);
         Destroy(gameObject);            
        }
    }
}
