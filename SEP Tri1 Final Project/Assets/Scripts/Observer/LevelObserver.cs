using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObserver : IObserver
{
    private LevelSubject subject;
    int level;
    
    public LevelObserver(LevelSubject subject)
    {
        this.subject = subject;
        subject.Attach(this);
        level = subject.getLevelState();
    }
    
    public void Update()
    {
        //Debug.Log("New level state: ", level);
    }
}
