using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene(1);
        print("starting game");
    }
    public void GameOver() {
        SceneManager.LoadScene(1);
    }
}
