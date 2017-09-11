using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

	private Animator tankAnimator;
	private Vector2 movement;
	private Rigidbody2D rigidBody;
	private float speed = 5f;


	void Awake() {
		tankAnimator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Move();
		Rotate();
		Animate();
	}

	void Move() {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		if (moveHorizontal != 0f)
			moveVertical = 0f;

		movement = new Vector2 (moveHorizontal, moveVertical) * speed * Time.deltaTime;
		rigidBody.MovePosition(rigidBody.position + movement);
	}

	void Rotate() {
		if (movement != new Vector2(0f, 0f)) {
			float xMovement = Mathf.Clamp(movement.x * 100, -1f, 1f);
			float yMovement = Mathf.Clamp(movement.y * 100, -1f, 1f);

			transform.rotation = Quaternion.LookRotation (Vector3.forward, new Vector2 (xMovement, yMovement));
		}
	}

	void Animate() {
		if (movement == new Vector2(0f, 0f))
			tankAnimator.SetBool("Moving", false);
		else
			tankAnimator.SetBool("Moving", true);
	}
}
