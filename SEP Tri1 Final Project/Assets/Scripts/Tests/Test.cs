using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestSimplePasses()
    {
        // Use the Assert class to test conditions
        
        bool isActive = false;
        Assert.AreEqual(false, isActive);

        int num1 = 1;
        int num2 = 1;
        Assert.AreEqual(num1, num2); // Should be (1, 1) --> numbers should be equal to each other
        
        num2++;
        Assert.AreNotEqual(num1, num2); // Should be (1, 2) --> numbers should NOT be equal to each other
        
        num1++;
        Assert.AreEqual(num1, num2); // Should be (2, 2) --> numbers should be equal to each other

        Assert.AreNotEqual(isActive, num1 == num2); // Should be (false, true) --> not equal

        GameObject gameObject = new GameObject("test");
        Assert.Throws<MissingComponentException>(
            () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one
        ); // Assert that Unity throws errors
        // Error here comes from the fact that a newly established GameObject "test" 
        // doesn't have a rigidbody component yet, leading to the error MissingComponentException 
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;

        var gameManager = GameObject.Find("GameManager");
        Assert.IsNotNull(gameManager);

        // Assert.AreEqual(true, gameManager.isGameActive);

        // Assert.IsNotNull(gameManager.testLives);
        // Assert.IsNotNull(gameManager.testSpawnRate);
        // Assert.IsNotNull(gameManager.testSpawnPosX);
        // Assert.IsNotNull(gameManager.testSpawnRangeY);

        // Assert.IsEqual(3, gameManager.testLives);
        // Assert.IsEqual(1.0f, gameManager.testSpawnRate);
        // Assert.IsEqual(12.5f, gameManager.testSpawnPosX);
        // Assert.IsEqual(4, gameManager.testSpawnRangeY);
    }
}
