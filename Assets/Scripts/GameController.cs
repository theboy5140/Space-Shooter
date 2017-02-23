using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameOverText;
    public GameObject restartButton;

    private bool gameOver;
    private bool restart;
    private int score;

	// Use this for initialization
	void Start () {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        scoreText.text = "Score ss:";
        restartButton.SetActive (false);
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves());
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator SpawnWaves(){
     
        yield return new WaitForSeconds (startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, +spawnValue.x), spawnValue.y, 16f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver) {
                restartButton.SetActive (true);
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

    public void RestartGame(){
    
        Application.LoadLevel (Application.loadedLevel);
    }
}
