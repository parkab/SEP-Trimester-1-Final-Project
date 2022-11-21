using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    public GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    delegate void MyDelegate(int num);
    MyDelegate weDelegateYouToStartTheGame;

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        weDelegateYouToStartTheGame = gameManager.StartGame; 
        weDelegateYouToStartTheGame(difficulty);
    }
}
