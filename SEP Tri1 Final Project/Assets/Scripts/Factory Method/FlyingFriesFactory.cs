using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingFriesFactory : FlyingThingFactory
{
    public override FlyingThing CreateFlyingThing()
    {
        return new FlyingFries();
    }
}
