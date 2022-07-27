using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart1;
    // Start is called before the first frame update
    private void Awake() {
        SpawnLevelPart(new Vector3(21, 0));
        SpawnLevelPart(new Vector3(21 + 18, 0));
        SpawnLevelPart(new Vector3(21 + 36, 0));
    }

    private void SpawnLevelPart(Vector3 spawnPosition) {
        Instantiate(levelPart1, spawnPosition, Quaternion.identity);
    }
}
