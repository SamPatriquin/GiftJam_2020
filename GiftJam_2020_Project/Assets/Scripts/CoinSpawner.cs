using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    
    [SerializeField] private ObjectPool pool;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private CoinFormation[] coinFormations;
    [SerializeField] private int maxCoins = 5;
    [SerializeField] private float maxHeight = 0f;
    [SerializeField] private float XOffset = 0f;

    private Vector2 lastPos;

    private int numCoins = 0;

    private void Awake() {
        lastPos = new Vector2(XOffset, Random.Range(-maxHeight, maxHeight));
    }

    private void Update() {
        if (numCoins < maxCoins) {
            GenerateCoins(coinFormations[Random.Range(0, coinFormations.Length)]);
        }
    }

    private void GenerateCoins(CoinFormation coinFormation) {
        Vector2 formationPos = new Vector2(lastPos.x + XOffset, Random.Range(-maxHeight, maxHeight));
        foreach (Vector2 coinPos in coinFormation.coinPositons) {
            GameObject coin = pool.GetObject(coinPrefab);
            if (coin.GetComponent<Coin>() != null) { coin.GetComponent<Coin>().spawnedFrom = this; }
            coin.transform.position = formationPos + coinPos;
            lastPos = coin.transform.position;
            ++numCoins;
        }
    }

    public void returnCoin(GameObject coin) {
        pool.ReturnObject(coin);
        --numCoins;
    }
}
