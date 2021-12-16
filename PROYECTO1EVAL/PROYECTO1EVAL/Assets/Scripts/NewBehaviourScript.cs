using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float randX;
    private float randY;
    private float randZ;
    public GameObject Coin;
    public GameObject Bill;
    private Vector3 randPos;
    public Player_Controller playerControllerScript;
    private float startSpawn = 2f;
    private float repeatSpawn = 5f;

    void Start()
    {
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();
        SpawnerR();

        InvokeRepeating("SpawnerObstacles", startSpawn, repeatSpawn);

        playerControllerScript = FindObjectOfType<Player_Controller>();
    }
    public void SpawnerObstacles()
    {
        if (!playerControllerScript.gameOver)
        {
            randX = Random.Range(140, -150);
            randY = Random.Range(0, 181);
            randZ = Random.Range(-97, 250);
            randPos = new Vector3(randX, randY, randZ);
            Instantiate(Bill, randPos, Bill.transform.rotation);
        }
    }
    public void SpawnerR()
    {
        randX = Random.Range(125, -151);
        randY = Random.Range(0, 181);
        randZ = Random.Range(-95, 250);
        randPos = new Vector3(randX, randY, randZ);
        Instantiate(Coin, randPos, Coin.transform.rotation);
    }

   
}
