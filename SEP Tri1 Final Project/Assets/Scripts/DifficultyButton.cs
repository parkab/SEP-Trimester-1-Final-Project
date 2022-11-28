using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    public GameManager gameManager;
    public SpawnRate spawnRate;

    // Start is called before the first frame updates
    void Start()
    {
        //Debug.Log("Difficulty: " + "Spawn Rate: " + 1.0f / spawnRate.spawnRate);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    delegate void MyDelegate(int difficulty, float spawnRate);
    MyDelegate weDelegateYouToStartTheGame;

    void SetDifficulty()
    {
        //Debug.Log(gameObject.name + " was clicked");
        Debug.Log(gameObject.name + " was clicked. " + "Difficulty: " + "Spawn Rate: " + spawnRate.spawnRate);
        weDelegateYouToStartTheGame = gameManager.StartGame; 
        weDelegateYouToStartTheGame(spawnRate.difficultyLevel, spawnRate.spawnRate);
    }
}
