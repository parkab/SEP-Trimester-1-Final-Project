using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public List<GameObject> objectPrefabs;
    public List<GameObject> hearts;
    public GameObject titleScreen;

    // private float startDelay = 1;
    private int lives = 3;
    private float spawnRate = 1.0f;

    private float spawnPosX = 12.5f;
    private float randX;
    private float spawnRangeY = 4;

    private int score;
    private float timer;
    private int difficulty;

    public bool isGameActive;
    public Button restartButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timerText.SetText("Time: " + Mathf.Round(timer));
            if (difficulty <= 3)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    GameOver();
                }
            }
            if (difficulty == 4)
            {
                timer += Time.deltaTime;
                spawnRate -= 0.01f * Time.deltaTime;
            }
        }
    }

    public void StartGame(int diff)
    {
        difficulty = diff;

        isGameActive = true;
        score = 0;

        if (difficulty <= 3)
        {
            timer = 30;
            spawnRate /= difficulty;
        }
        if (difficulty == 4)
        {
            timer = 0;
            spawnRate = 1.0f;
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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void UpdateLives()
    {
        lives -= 1;
        hearts[lives].SetActive(false);
        Debug.Log(lives);

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
