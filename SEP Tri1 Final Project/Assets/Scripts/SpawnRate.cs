using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnRate", menuName = "SpawnRate")]
public class SpawnRate : ScriptableObject
{
    public string difficultyName;
    public int difficultyLevel;
    public float spawnRate;
}
