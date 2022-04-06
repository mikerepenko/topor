using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayBtn : MonoBehaviour {

	public float speed;
	public bool isAnim = false;

	void Update () {
		if(isAnim)
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, -1f, transform.position.z), speed * Time.deltaTime);
		else
			transform.position = new Vector3(transform.position.x, -6f, transform.position.z);
	}
	public void YesBtn(){
		isAnim = true;
	}
	public void NoBtn(){
		isAnim = false;
	}
}
