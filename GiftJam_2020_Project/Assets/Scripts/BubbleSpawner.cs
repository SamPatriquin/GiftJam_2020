using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] bubblePrefabs;
    [SerializeField] private ObjectPool bubblePool;
    [SerializeField] private float xOffset;
    [SerializeField] private float maxHeight;
    [SerializeField] private int maxBubbles;

    private Vector2 lastSpawnPos = new Vector2(0f, 0f);
    private int numBubbles = 0;

    private void Awake() {
        OnBubbleWithPlayer.PlayerLeftBubble += ReturnBubble;
        GameObject bubble = bubblePool.GetObject(bubblePrefabs[0]);
        bubble.transform.position = new Vector2(0f, 0f);
        ++numBubbles;
    }

    private void Update() {
        if (numBubbles < maxBubbles) {
            GameObject bubble = bubblePool.GetObject(bubblePrefabs[0]);
            bubble.transform.position = new Vector2(lastSpawnPos.x + Random.Range(xOffset-1, xOffset+1), Random.Range(-maxHeight, maxHeight));
            lastSpawnPos = bubble.transform.position;
            ++numBubbles;
        }
    }

    private void ReturnBubble(GameObject bubble) {
        bubblePool.ReturnObject(bubble);
        --numBubbles;
    }
}
