using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private GameManager gameManager;
    public ParticleSystem redExplosionParticle;
    private GameObject GameCamera;
    private Shake shake;


    public int pointValue;
    private float speed = .1f;
    private float speedX;
    private float speedY;
    private bool spawnLeft;

    private float leftBound = -12.5f;
    private float rightBound = 12.5f;
    private float verticalBound = 4.6f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameCamera = GameObject.Find("Main Camera");
        shake = GameCamera.GetComponent<Shake>();

        // determine which side the object spawned
        spawnLeft = transform.position.x < 0;

        // randomize angle and speed
        speedX = Random.Range(50, 100) * Time.deltaTime * speed;
        speedY = Random.Range(-100, 100) * Time.deltaTime * speed;

        redExplosionParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            // object movement
            if (spawnLeft)
            {
                //transform.Translate(Vector2.right * Time.deltaTime * speed);
                transform.Translate(speedX, speedY, 0);
            }
            else
            {
                //transform.Translate(Vector2.left * Time.deltaTime * speed);
                transform.Translate(-speedX, speedY, 0);
            }

            // lets objects bounce off top and bottom walls
            if ((transform.position.y < -verticalBound) || (transform.position.y > verticalBound))
            {
                speedY = -speedY;
            }

            // destroy object out of bounds
            if ((spawnLeft && transform.position.x > rightBound) || (!spawnLeft && transform.position.x < leftBound))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Food"))
            {
                Debug.Log("Food");
                Destroy(gameObject);
                gameManager.UpdateScore(pointValue);
            }
            if (gameObject.CompareTag("Rock"))
            {
                //Debug.Log("ROCK");
                //objectPos = gameObject.transform.position;
                //redExplosionParticle.Play();
                //redExplosionParticle.Stop();
                //StartCoroutine(PlayParticle());

                Destroy(gameObject);
                gameManager.UpdateLives();
                shake.start = true;
            }

        }
        // zaman blessing
        bool dominance = true;
        Debug.Assert(dominance);
    }
}
