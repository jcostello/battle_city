using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour, IShotable {

	public void Hit(Transform transform) {
		Debug.Log ("Entro Tanque");
	}
}
