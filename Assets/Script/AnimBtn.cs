using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBtn : MonoBehaviour {

	public float speed;
	public bool isPlay = false;
	private string btn;

	public void YesPlay(){
		isPlay = true;
	}
	public void NoPlay(){
		isPlay = false;
	}
	void Start(){
		if (gameObject.name == "Music")
			btn = "Music";
		if (gameObject.name == "Shop")
			btn = "Shop";
		if (gameObject.name == "Ads")
			btn = "Ads";
		if (gameObject.name == "Records")
			btn = "Records";
	}
	void Update () {
		if (isPlay) {
			if (btn == "Records" || btn == "Music")
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-5f, transform.position.y, transform.position.z), speed * Time.deltaTime);
			else if (btn == "Shop" || btn == "Ads")
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (5f, transform.position.y, transform.position.z), speed * Time.deltaTime);
		} else if (!isPlay)
		{
			if (btn == "Records" || btn == "Music")
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-2.20f, transform.position.y, transform.position.z), speed * Time.deltaTime);
			else if (btn == "Shop" || btn == "Ads")
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (2.10f, transform.position.y, transform.position.z), speed * Time.deltaTime);
		}
	}
}