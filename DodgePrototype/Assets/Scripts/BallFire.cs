using UnityEngine;
using System.Collections;

public class BallFire : MonoBehaviour {

	// Movement variables
	public float speed;

	bool moving = true;

	private Vector3 direction;

	private Rigidbody body;
	private GameObject target;

	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody>();
		target = GameObject.FindWithTag("Player");

		// Init movement variables
		moving = true;

		//calculate direction ( target position - current position)
		direction = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		// Move positively in the X axis
		if (moving) {
			body.velocity = direction * speed;
		}
	}
}