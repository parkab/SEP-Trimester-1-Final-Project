using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIceCream : FlyingThing
{
    public GameObject myIce;
    private float spawnRangeY = 4;
    private float spawnPosX = 12.5f;
    private float randX;


    public override void Fly()
    {
        // Right side
        randX = -1;

        // determine which object will spawn and object spawn position
        Vector2 spawnPos = new Vector2(randX * spawnPosX, Random.Range(-spawnRangeY, spawnRangeY));

        Instantiate(myIce, spawnPos, myIce.transform.rotation);
    }
}
