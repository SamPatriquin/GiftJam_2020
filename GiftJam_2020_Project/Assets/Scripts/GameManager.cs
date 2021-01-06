using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private AudioManager audioManager;

    private void Start() { //Preload
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlaySound("mainTheme", this.gameObject);
        SceneManager.LoadScene(1);
    }

    private void Update() {
    }

    public void StartGame() {
        SceneManager.LoadScene(2);
    }

    public void GameOver() {
        SceneManager.LoadScene(2);
    }
}
