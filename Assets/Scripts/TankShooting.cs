using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {

	public GameObject shotPrefab;
	public Transform barrelTransform;

	private float fireRate = 0.5F;
	private float nextFire = 0.0F;

	void Update () {
		float fireButton = Input.GetAxisRaw("Fire1");

		if (fireButton > 0 && NextTimeToShoot()) {
			nextFire = Time.time + fireRate;

			CreateShoot();
		}
	}

	bool NextTimeToShoot() {
		return Time.time > nextFire;
	}

	void CreateShoot() {
		Instantiate (shotPrefab, barrelTransform.position + barrelTransform.up * .1f, barrelTransform.rotation);
	}

}
