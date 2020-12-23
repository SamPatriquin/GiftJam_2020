using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnBubbleWithPlayer : MonoBehaviour {

    public static event Action<GameObject> PlayerLeftBubble;

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<PlayerMovementController>()) {
            //Animation
            //Sound
            if (PlayerLeftBubble != null) {
                PlayerLeftBubble(this.gameObject);
            }
        }
    }
}
