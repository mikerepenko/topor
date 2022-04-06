using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracles : MonoBehaviour {

	private bool isRight = false;
	public float speed;
	Rigidbody2D obstracle;
	private bool isJump = false;

	void Start(){
		speed = Random.Range(3, 17);
		obstracle = GetComponent<Rigidbody2D>();
	}
	void Update () {
		if (gameObject.transform.localPosition.x >= 2.3)
			isRight = false;
		else if (gameObject.transform.localPosition.x <= -2.3)
			isRight = true;
		if(isRight)
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (3, transform.position.y, transform.localPosition.z), speed * Time.deltaTime);
		else if(!isRight)
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (-3, transform.position.y, transform.localPosition.z), speed * Time.deltaTime);
		if (isJump)
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (transform.position.x, 9f, transform.localPosition.z), speed * Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "topor") {
			Destroy (gameObject, 0.3F);
			obstracle.constraints = RigidbodyConstraints2D.None;
			PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + 1);
			isJump = true;
			//obstracle.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
		}
	}
}
