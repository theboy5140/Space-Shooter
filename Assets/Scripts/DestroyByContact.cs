using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
		
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
        }
        Destroy (other.gameObject);
        Destroy (gameObject);
    }
}
