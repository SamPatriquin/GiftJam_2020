using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] bubblePrefabs; //Regular=0, Fast=1
    [SerializeField] private ObjectPool pool;
    [SerializeField] private float xOffset;
    [SerializeField] private float maxHeight;
    [SerializeField] private int maxBubbles;

    private Vector2 lastSpawnPos = new Vector2(0f, 0f);
    private int numBubbles = 0;

    private void Awake() {
        GameObject bubble = pool.GetObject(bubblePrefabs[0]);
        if (bubble.GetComponent<Bubble>() != null) { bubble.GetComponent<Bubble>().spawnedFrom = this; }
        bubble.transform.position = new Vector2(0f, 0f);
        ++numBubbles;
    }

    private void Update() {
        if (numBubbles < maxBubbles) {
            GameObject bubble = pool.GetObject(bubblePrefabs[0]);
            if (bubble.GetComponent<Bubble>() != null) { bubble.GetComponent<Bubble>().spawnedFrom = this; }
            bubble.transform.position = new Vector2(lastSpawnPos.x + Random.Range(xOffset-1, xOffset+1), Random.Range(-maxHeight, maxHeight));
            lastSpawnPos = bubble.transform.position;
            ++numBubbles;
        }
    }

    public void ReturnBubble(GameObject bubble) {
        pool.ReturnObject(bubble);
        --numBubbles;
    }
}
