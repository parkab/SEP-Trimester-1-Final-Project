using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Rock flyingPrefab;
    private IObjectPool<Rock> flyingPool;

    public Rock myRock;

    private GameManager gameManager;
    public ParticleSystem redExplosionParticle;
    private GameObject GameCamera;
    private Shake shake;
    public int pointValue;
    private float speedX;
    private float speedY;
    private bool spawnLeft;
    public List<GameObject> objectPrefabs;
    public List<GameObject> hearts;
    public GameObject titleScreen;
    public GameObject player;
    private float spawnPosX = 12.5f;
    private float randX;
    private float spawnRangeY = 4;
    private int score;
    private float timer;
    private int difficulty;

    private void Awake()
    {
        flyingPool = new ObjectPool<Rock>(CreateFlying, GetFlying, ReleaseFlying, DestroyFlying, maxSize: 30);
    }


    private Rock CreateFlying()
    { 
        // determine which side object will spawn on
        randX = Random.Range(0, 2);
        if (randX >= 1)
        {
            randX = 1;
        }
        else
        {
            randX = -1;
        }

        // determine which object will spawn and object spawn position
        Vector2 spawnPos = new Vector2(randX * spawnPosX, Random.Range(-spawnRangeY, spawnRangeY));

        // spawn object
        Rock thing = Instantiate(myRock, spawnPos, myRock.transform.rotation);
        thing.SetPool(flyingPool);
        return thing;
    }

    private void GetFlying(Rock thing)
    {
        thing.gameObject.SetActive(true);
        thing.transform.position = transform.position;
    }

    private void ReleaseFlying(Rock thing)
    {
        thing.gameObject.SetActive(false);
    }

    private void DestroyFlying(Rock thing)
    {
        Destroy(thing.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            flyingPool?.Get();
        }
    }
}