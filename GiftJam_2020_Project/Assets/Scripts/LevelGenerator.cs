using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [Header("Bubbles")]
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private int minBubbles;

    [Header("Coins")]
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private CoinFormation[] coinFormations;

    [Header("Obstacles")]
    [SerializeField] private GameObject[] obstaclePrefabs;

    [Header("General Settings")]
    [SerializeField] private ObjectPool pool;
    [SerializeField] private float maxHeight;
    [SerializeField] private float minSpawnDist;
    [SerializeField] private float maxSpawnDist;


    private Vector2 lastBubbleSpawnPos;

    private int numBubbles = 0;


    private void Awake() {
        lastBubbleSpawnPos = SpawnBubble(Vector2.zero);
    }

    private void Update() {
        if (numBubbles < minBubbles) {
            lastBubbleSpawnPos = SpawnBubble(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist), Random.Range(-maxHeight, maxHeight)));
            SpawnCoinFormation(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist) / 2, Random.Range(-maxHeight/2, maxHeight/2)));
            SpawnObstacle(new Vector2(lastBubbleSpawnPos.x + Random.Range(minSpawnDist, maxSpawnDist) / 2, Random.Range(-maxHeight / 2, maxHeight / 2)));
        }
    }

    private Vector2 SpawnBubble(Vector2 spawnAt) {
        GameObject bubble = pool.GetObject(bubblePrefab);
        Bubble bubbleComponent = bubble.GetComponent<Bubble>();
        if (bubbleComponent != null) { bubbleComponent.spawnedFrom = this; }
        bubble.transform.position = spawnAt;
        ++numBubbles;
        return bubble.transform.position;
    }

    private void SpawnCoinFormation(Vector2 spawnAt) {
        CoinFormation formation = coinFormations[Random.Range(0, coinFormations.Length)];
        foreach (Vector2 pos in formation.coinPositons) {
            GameObject coin = pool.GetObject(coinPrefab);
            Coin coinComponent = coin.GetComponent<Coin>();
            if (coinComponent != null) { coinComponent.spawnedFrom = this; }
            coin.transform.position = spawnAt + pos;
        }
    }

    private void SpawnObstacle(Vector2 spawnAt) {
        GameObject obstacle = pool.GetObject(obstaclePrefabs[0]);
        UpDownObstacle upDownObstacle = obstacle.GetComponent<UpDownObstacle>();
        if (upDownObstacle != null) { upDownObstacle.spawnedFrom = this; }
        obstacle.transform.position = spawnAt;
    }

    public void despawnBubble(GameObject bubble) {
        --numBubbles;
        pool.ReturnObject(bubble); 
    }

    public void despawnCoin(GameObject coin) {
        pool.ReturnObject(coin);
    }

    public void despawnObstacle(GameObject obstacle) {
        pool.ReturnObject(obstacle);
    }
}
