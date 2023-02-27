using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Random2Strategy : IStrategy
{
    public int Random(int a, int b)
    {
        return b;
    }
}
