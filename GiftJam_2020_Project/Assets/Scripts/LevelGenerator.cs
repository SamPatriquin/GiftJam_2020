using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [Header("Bubbles")]
    [SerializeField] private GameObject bubblePrefab;

    [Header("Coins")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private CoinFormation[] coinFormations;

    [Header("Obstacles")]
    [SerializeField] private GameObject[] obstaclePrefabs;

    [Header("General Settings")]
    [SerializeField] private ObjectPool pool;
    [SerializeField] private float spawnAhead = 20f;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minSpawnDist;
    [SerializeField] private float maxSpawnDist;

    private Transform playerTransform;
    private Vector2 lastBubbleSpawnPos;


    private void Awake() {
        lastBubbleSpawnPos = SpawnBubble(Vector2.zero);
        PlayerMovementController player = FindObjectOfType<PlayerMovementController>();
        if (player != null) { playerTransform = player.transform; }
    }

    private void Update() {
        if (lastBubbleSpawnPos.x <= playerTransform.position.x + spawnAhead) {
            lastBubbleSpawnPos = SpawnBubble(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist), Random.Range(-maxHeight, maxHeight)));
            SpawnCoinFormation(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist) / 2, Random.Range(-maxHeight/2, maxHeight/2)));
            SpawnObstacle(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist) / 2, Random.Range(-maxHeight / 2, maxHeight / 2)));
        }
    }

    private Vector2 SpawnBubble(Vector2 spawnAt) {
        GameObject bubble = pool.GetObject(bubblePrefab);
        bubble.transform.position = spawnAt;
        return bubble.transform.position;
    }

    private void SpawnCoinFormation(Vector2 spawnAt) {
        CoinFormation formation = coinFormations[Random.Range(0, coinFormations.Length)];
        foreach (Vector2 pos in formation.coinPositons) {
            GameObject coin = pool.GetObject(coinPrefab);
            coin.transform.position = spawnAt + pos;
        }
    }

    private void SpawnObstacle(Vector2 spawnAt) {
        GameObject obstacle = pool.GetObject(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
        obstacle.transform.position = spawnAt;
        IObstacle _obstacle = obstacle.GetComponent<IObstacle>();
        _obstacle.spawnedAt = spawnAt;
    }
}
