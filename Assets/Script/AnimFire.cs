using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFire : MonoBehaviour {

	public float speed;
	public float speedRotate;
	public bool isFire = false;
	public GameManager gameManager;
	[SerializeField]
	private float timer;
	private bool isTimer;
	public AudioSource crash;
	public AudioSource fire;
	public AudioSource gameover;

	public int rund;
	public GameObject getMoney;

	void FixedUpdate(){
		if (isTimer) {
			timer += 0.2F;
			if (timer > 3) {
				NoFire ();
				timer = 0;
				isTimer = false;
			}
		}
	}
	void Update () {
		if (isFire) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (transform.localPosition.x, 11f, transform.localPosition.z), speed * Time.deltaTime);
			transform.Rotate (0, 0, speedRotate * Time.deltaTime * 40f);
			if (gameObject.transform.localPosition.y >= 11) {
				NoFire ();
				gameManager.Gameover ();
				gameManager.StopPlaySound ();
				gameover.Play ();
			}
		} else if (!isFire) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (transform.localPosition.x, 0f, transform.localPosition.z), speed * Time.deltaTime);
		}
	}
	public void Fire(){
		isFire = true;
		fire.Play ();
	}
	public void NoFire(){
		isFire = false;
		transform.rotation = new Quaternion(0, 0, 0, 0);
		transform.position = new Vector3(transform.position.x, -4.88f, transform.position.z);
	}
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "obst") {
			isTimer = true;
			crash.Play ();
			rund = Random.Range (1, 5);
			if (rund == 3) {
				PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") + 1);
				getMoney.SetActive (true);
			}
		}
	}
}
