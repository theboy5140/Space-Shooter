using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3 (Mathf.Clamp(Random.value * 6, -6f, 6f), 0f, Mathf.Clamp(Random.value * 14, -14f, 14f));

        GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
