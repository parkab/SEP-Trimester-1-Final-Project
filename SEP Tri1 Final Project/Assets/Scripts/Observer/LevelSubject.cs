using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSubject : Subject
{
    private int levelState;
    
    public int State
    {
        get { return levelState; }
        set
        {
            levelState = Random.Range(1, 5);
            Notify();
        }
    }

    public int getLevelState()
    {
        return this.levelState;
    }
}
