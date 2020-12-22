using System;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] 
    private int value;

    public static event Action<int> onCoinPickup;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            if (onCoinPickup != null) {
                onCoinPickup(this.value);
            }
        }
    }
}
