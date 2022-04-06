using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour {

	public float speed;

	void Update () {
		if (gameObject.transform.localPosition.y >= 10) {
			transform.position = new Vector3(transform.position.x, -2.3f, transform.position.z);
			gameObject.SetActive (false);
		}
		else
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (transform.position.x, 11f, transform.localPosition.z), speed * Time.deltaTime);
	}
}
