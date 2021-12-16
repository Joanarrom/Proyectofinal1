using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Object : MonoBehaviour
{
    private float rotateSpeed = 366f;
        public Player_Controller playerControllerScript;
   
    void Start()
    {
        playerControllerScript = FindObjectOfType<Player_Controller>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {           
            if (gameObject.CompareTag("helices"))
            { transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed); }
                                 
        }



    }
}
