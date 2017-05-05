using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update () {
		if (!hasStarted) {
			//lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//wait for a mouse press to launch.
			if (Input.GetMouseButton (0)) {
				print ("mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			GetComponent<AudioSource> ().Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
