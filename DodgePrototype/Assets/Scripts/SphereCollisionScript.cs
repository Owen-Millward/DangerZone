using UnityEngine;
using System.Collections;

public class SphereCollisionScript : MonoBehaviour {

	private MeshRenderer rend;

	// Use this for initialization
	void Start () {

		// Get mesh renderer
		rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update(){

		// Check if out of playable area on positive X side
		if (transform.position.x > 2) {
			// Reset to default position
			transform.position.Set(-5.0f, 2.0f, 0.0f);
		}
	}

	// Check for collision event
	void OnTriggerEnter(Collider collider){

		if (collider.tag == "Player"){
			rend.material.SetColor("_Color", Color.red);
		}
	}

	void OnTriggerExit(Collider collider){

		if (collider.tag == "Player"){
			rend.material.SetColor("_Color", Color.blue);
		}
	}
}