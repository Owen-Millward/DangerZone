using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	private float gravity = 9.8f;

	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);
		
		ThrowBall();
	}

	void Update (){

		if (transform.position.y < -10) {
			Destroy (this.gameObject);
		}
	}

	void ThrowBall (){

		// Calculate direction and distance of target
		Vector3 direction = (target.position - transform.position).normalized;
		float distance = Vector3.Distance(transform.position, target.transform.position);

		// Decide a firing angle based on distance (for now use 45)
		float theta = 45.0f;
		direction.y = (theta / 90.0f);

		// Calculate velocity required to hit target (Range equation)
		float velocity = Mathf.Sqrt(gravity * distance / (Mathf.Sin(2 * theta * Mathf.Deg2Rad)));

		// Direction of throw * Velocity required to hit target
		body.AddForce(direction * velocity * 50.0f);
	}
}