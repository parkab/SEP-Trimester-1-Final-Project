using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingThingFactory : MonoBehaviour
{
    public abstract FlyingThing CreateFlyingThing();
}
