using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameCongoller;

	// Use this for initialization
	void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null) {
            gameCongoller = gameControllerObject.GetComponent<GameController> ();
        } else {
            Debug.Log ("Cannot fild 'GameController' script ");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        Instantiate (explosion, transform.position, transform.rotation);

        if (other.tag == "Player") {
            
            Instantiate (playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
        
            gameCongoller.GameOver ();
        }

        gameCongoller.AddScore (scoreValue);
        Destroy (other.gameObject);
        Destroy (gameObject);
    }
}
