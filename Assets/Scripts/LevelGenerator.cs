using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform starting_level_part;
    [SerializeField] private Transform levelPart1;

    [SerializeField] private Transform player;

    private const float DISTANCE_TO_SPAWN = 30f;
    private Vector3 lastEndPosition;
    // Start is called before the first frame update
    private void Awake() {
        lastEndPosition = starting_level_part.Find("EndPosition").position;
        // Transform lastLevelTransform = SpawnLevelPart(starting_level_part.Find("EndPosition").position);
        // lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        // lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        // lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
        // lastLevelTransform = SpawnLevelPart(lastLevelTransform.Find("EndPosition").position);
    }

    private void Update() {
        if (Vector3.Distance(player.position, lastEndPosition) < DISTANCE_TO_SPAWN) {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        Transform levelPart = CalculateAndSpawnLevelPart(lastEndPosition);
        lastEndPosition = levelPart.Find("EndPosition").position;
    }

    private Transform CalculateAndSpawnLevelPart(Vector3 spawnPosition) {
        return Instantiate(levelPart1, new Vector3(spawnPosition.x + 10.75f, 0), Quaternion.identity);
    }
}
