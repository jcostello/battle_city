using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {

	public GameObject shotPrefab;
	public Transform barrelTransform;
	public GameObject shot;

	private float fireRate = .4f;
	private float nextFire = .0f;

	void Update () {
		float fireButton = Input.GetAxisRaw("Fire1");

		if (fireButton > 0 && CanShoot()) {
			nextFire = Time.time + fireRate;

			CreateShoot();
		}
	}

	bool CanShoot() {
		return Time.time > nextFire && shot == null;
	}

	void CreateShoot() {
		shot = Instantiate (shotPrefab, barrelTransform.position + barrelTransform.up * .1f, barrelTransform.rotation) as GameObject;
	}
}
