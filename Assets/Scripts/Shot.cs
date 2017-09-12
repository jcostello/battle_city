using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public GameObject explosionPrefab;

	private Rigidbody2D rigidBody;
	private float shotLifeTime = 3f;
	private float shotSpeed = 10f;

	void Awake () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Start () {
		Destroy (gameObject, shotLifeTime);

		rigidBody.velocity = transform.up * shotSpeed;
	}

	void OnCollisionEnter2D(Collision2D other) {
		Instantiate (explosionPrefab, transform.position, Quaternion.identity);

		Destroy(gameObject);
	}
}
