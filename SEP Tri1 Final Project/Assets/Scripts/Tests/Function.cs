using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;

public class Function
{
    //public GameManager gameManager;


    // A Test behaves as an ordinary method
    [Test]
    public void FunctionSimplePasses()
    {
        // Use the Assert class to test conditions
        
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Assert(gameManager.isGameActive == false);
        // Start();
        // Assert(gameManager.isGameActive == true);

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator FunctionWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
