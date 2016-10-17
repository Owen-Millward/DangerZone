using UnityEngine;
using System.Collections;

public class BallThrow : MonoBehaviour {

	private Rigidbody body;
	private Transform target;

	public float velocity;
	public float distance;
	public Vector3 direction;
	public Vector3 directionThrow;
	public float scale;

	// Use this for initialization
	void Start () {

		body = GetComponent<Rigidbody>();
		target = (GameObject.FindWithTag("Player").transform);
		
		ThrowBall();
	}

	void ThrowBall (){

		// Calculate direction and distance of target
		direction = (target.position - transform.position).normalized;
		distance = Vector3.Distance(transform.position, target.transform.position);

		// Decide a firing angle based on distance (for now use 45)
		float theta = 45.0f;

		// Calculate velocity required to hit target
		velocity = Mathf.Sqrt(distance / (Mathf.Sin(2 * theta * Mathf.Deg2Rad) / 9.8f));

		// Horizontal and Vertical components of velocity
		float Vy = velocity * Mathf.Sin(theta * Mathf.Deg2Rad);
		float Vx = velocity * Mathf.Cos(theta * Mathf.Deg2Rad);
		
		// X and Z components
		//float Vx = velocity_h * Mathf.Cos(theta * Mathf.Deg2Rad);
		//float Vz = velocity_h * Mathf.Sin(theta * Mathf.Deg2Rad);

		// Direction of throw = Velocity required to hit target
		directionThrow = new Vector3(Vx, Vy, 0);
		body.AddForce(directionThrow * velocity * scale);
	}
}