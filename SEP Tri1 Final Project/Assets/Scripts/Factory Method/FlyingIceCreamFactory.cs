using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIceCreamFactory : FlyingThingFactory
{
    public override FlyingThing CreateFlyingThing()
    {
        return new FlyingIceCream();
    }
}
