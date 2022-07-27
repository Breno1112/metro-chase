using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform starting_level_part;
    [SerializeField] private Transform levelPart1;
    // Start is called before the first frame update
    private void Awake() {
        Transform lastLevelTransform = SpawnLevelPart(starting_level_part.Find("EndPosition").position);
        lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition) {
        return Instantiate(levelPart1, new Vector3(spawnPosition.x + 10.75f, 0), Quaternion.identity);
    }
}
