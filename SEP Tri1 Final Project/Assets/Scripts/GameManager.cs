using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> objectPrefabs;
    // private float startDelay = 1;
    private float spawnRate = 1.0f;

    private float spawnPosX = 12.5f;
    private float randX;
    private float spawnRangeY = 4;

    private int score;
    private float timer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    //public TextMeshProUGUI gameOverText;

    public bool isGameActive;
    //public Button restartButton;

    //public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartGame(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timerText.SetText("Time: " + Mathf.Round(timer));
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameOver();
            }
        }
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        timer = 30;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        //titleScreen.gameObject.SetActive(false);
        //
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
    public void GameOver()
    {
        isGameActive = false;
        //gameOverText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
