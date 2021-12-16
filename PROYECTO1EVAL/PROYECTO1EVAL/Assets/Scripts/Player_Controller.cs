using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player_Controller : MonoBehaviour
{

    private float verticalInput;
    private float horizontalInput;
    public GameObject proyectilPrefab;

    public bool gameOver;
    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI winText;
    public int coin = 0;

    private float speed = 13f;
    private float turnSpeed = 30f;
    private AudioSource audioPlayer;
    public AudioClip coinClip;
    public AudioSource audioCamera;




    
    void Start()
    {          
        transform.position = new Vector3(0, 100, 0);               
        coin = 0;       
        winText.gameObject.SetActive(false);        
        audioPlayer = GetComponent<AudioSource>();
        audioCamera = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }    
    void Update()
    {
        if (!gameOver)
        {           
            transform.Translate(Vector3.forward * Time.deltaTime * speed);                        
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");            
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);            
      
            if (transform.position.y >= 200)
            { transform.position = new Vector3(transform.position.x, 200, transform.position.z); }
            if (transform.position.y <= 0)
            { transform.position = new Vector3(transform.position.x, 0, transform.position.z); }

            if (transform.position.x >= 200)
            { transform.position = new Vector3(200, transform.position.y, transform.position.z); }
            if (transform.position.x <= -200)
            { transform.position = new Vector3(-200, transform.position.y, transform.position.z); }

            if (transform.position.z >= 350)
            { transform.position = new Vector3(transform.position.x, transform.position.y, 350); }
            if (transform.position.z <= -100)
            { transform.position = new Vector3(transform.position.x, transform.position.y, -100); }
          
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
            { 
                Instantiate(proyectilPrefab, transform.position, gameObject.transform.rotation);
            }

            CounterText.text = $"coin: {coin} / 10";

            if (coin == 10)
            {
                winText.text = $"WIN";
                winText.gameObject.SetActive(true);
                audioCamera.Stop();
                gameOver = true;
            }

        }
    }

    public void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver) 
        {
            if (otherCollider.gameObject.CompareTag("Recolectable"))
            {
                Destroy(otherCollider.gameObject);

                coin = coin + 1;

                audioPlayer.PlayOneShot(coinClip, 1);
            }

            else if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Destroy(otherCollider.gameObject);
                Destroy(gameObject);

                winText.text = $"GAME OVER";
                winText.gameObject.SetActive(true);
                
                audioCamera.Stop();

                gameOver = true;
            }
        }
        }
}
