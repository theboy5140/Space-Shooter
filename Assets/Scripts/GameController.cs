using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;

    public Vector3 spawnValue;

	// Use this for initialization
	void Start () {
        SpawnWaves ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnWaves(){
     
        Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, +spawnValue.x), spawnValue.y, 16f);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate (hazard, spawnPosition, spawnRotation);
        Debug.Log (spawnPosition);
    }
}
