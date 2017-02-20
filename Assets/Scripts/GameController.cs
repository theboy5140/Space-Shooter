using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
        if (restart) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
	}

    IEnumerator SpawnWaves(){
     
        yield return new WaitForSeconds (startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, +spawnValue.x), spawnValue.y, 16f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver) {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore(){
        scoreText.text = "Score： " + score;
    }

    public void AddScore(int scoreValue){

        score += scoreValue;
        UpdateScore ();
    }

    public void GameOver(){
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
