using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objectPrefabs;
    public List<GameObject> hearts;
    public GameObject titleScreen;
    public GameObject player;

    // private float startDelay = 1;
    private int lives = 3;
    private float spawnRate = 1.0f;

    private float spawnPosX = 12.5f;
    private float randX;
    private float spawnRangeY = 4;

    private int score;
    private float timer;
    private int difficulty;

    enum Level {
        Low = 1,
        Medium = 2,
        High = 3, 
        Endless = 4
    }
    Level gameDifficulty;

    public bool isGameActive;
    public Button restartButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public ParticleSystem redExplosionParticle;
    public ParticleSystem greyExplosionParticle;
    public ParticleSystem pinkExplosionParticle;
    public ParticleSystem goldExplosionParticle;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake(){
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        redExplosionParticle.Stop();
        greyExplosionParticle.Stop();
        pinkExplosionParticle.Stop();
        goldExplosionParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timerText.SetText("Time: " + Mathf.Round(timer));
            if (gameDifficulty != Level.Endless)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    GameOver();
                }
            }
            if (gameDifficulty == Level.Endless)
            {
                timer += Time.deltaTime;
                spawnRate -= 0.01f * Time.deltaTime;
            }
        }
    }

    public void StartGame(int difficulty)
    {
        gameDifficulty = (Level)difficulty;
        isGameActive = true;
        score = 0;

        if (gameDifficulty == Level.Endless)
        {
            timer = 0;
            spawnRate = 1.0f;
        }
        else if (gameDifficulty != Level.Endless)
        {
            timer = 30;
            spawnRate /= (int)gameDifficulty;
        }

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

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
            int objectIndex = Random.Range(0, objectPrefabs.Count);
            Vector2 spawnPos = new Vector2(randX * spawnPosX, Random.Range(-spawnRangeY, spawnRangeY));

            // spawn object
            Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
        }
    }

    IEnumerator PlayParticle(ParticleSystem particle, bool isObject)
    {
        if (isObject)
        {
            particle.transform.position = player.transform.position;
        }
        else
        {
            particle.transform.position = hearts[lives].transform.position;
        }
        particle.Play();
        yield return new WaitForSeconds(0.1f);
        particle.Stop();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (scoreToAdd == 5)
            StartCoroutine(PlayParticle(redExplosionParticle, true));
        if (scoreToAdd == 10)
            StartCoroutine(PlayParticle(pinkExplosionParticle, true));
        if (scoreToAdd == 20)
            StartCoroutine(PlayParticle(goldExplosionParticle, true));
    }

    public void UpdateLives()
    {
        lives -= 1;
        hearts[lives].SetActive(false);

        //Instantiate(redExplosionParticle, hearts[lives].transform.position, redExplosionParticle.transform.rotation);
        StartCoroutine(PlayParticle(redExplosionParticle, false));
        StartCoroutine(PlayParticle(greyExplosionParticle, true));

        Debug.Log("Lives: " + lives);

        if (lives == 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
