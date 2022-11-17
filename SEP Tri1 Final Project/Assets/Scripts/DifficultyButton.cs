using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    public GameManager gameManager;
    public int difficulty;
    enum Diff {
        Low,
        Medium,
        High, 
        Endless
    }
    Diff diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = (Diff)difficulty;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
