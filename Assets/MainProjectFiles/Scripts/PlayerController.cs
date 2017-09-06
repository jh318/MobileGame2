using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float accelX = 1;
	public float accelY = 1;
	public float maxVelocity = 5.0f;

	Rigidbody2D body;

	public delegate void PlayerDeath();
	public static event PlayerDeath playerDeath = delegate{};

	void OnTriggerEnter2D(Collider2D c){
		if(c.gameObject.GetComponentInParent<EnemyController>()){
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			playerDeath();
		}
	}

	void Start(){
		body = GetComponent<Rigidbody2D>();
	}

	void Update(){
		Vector3 accel = new Vector3(Input.acceleration.x * accelX, Input.acceleration.y * accelY, 0);
		body.AddForce(accel, ForceMode2D.Force);

		if(body.velocity.magnitude > maxVelocity){
			body.velocity = body.velocity.normalized * maxVelocity;
		}

		Vector3 currentPlayerPosition = Camera.main.WorldToViewportPoint(transform.position);
		currentPlayerPosition.x = Mathf.Clamp01(currentPlayerPosition.x);
		currentPlayerPosition.y = Mathf.Clamp01(currentPlayerPosition.y);
		transform.position = Camera.main.ViewportToWorldPoint(currentPlayerPosition);
	}
}

