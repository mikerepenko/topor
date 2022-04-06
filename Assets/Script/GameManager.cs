using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public AnimBtn music, ads, shop, records;
	public AnimPlayBtn btnPlay1, btnPlay2;
	public GameObject name, play, topor;
	public Sprite oneT, twoT, threeT, fourT, fiveT, sixT;
	public Sprite oneF, twoF, threeF, fourF, fiveF, sixF;
	public GameObject m_on, m_off;
	public GameObject score;
	public Text scoreText;
	public Text recordText;
	public bool isStart;
	public int rund;
	public float pos;
	public Text money;

	public AnimFire animFire;
	public GameObject fire;

	public AudioSource click;
	public AudioSource menuSound;
	public AudioSource playSound;
	public AudioSource gameover;

	public GameObject oneObs;
	public GameObject twoObs;
	public GameObject threeObs;

	private GameObject visibleObject;

	public GameObject recordPanel;
	public GameObject notification;
	public Text top;

	private int shopMoney = 200;
	public GameObject tLock1, tLock2, tLock3, tLock4, tLock5, tLock6;
	public GameObject fLock1, fLock2, fLock3, fLock4, fLock5, fLock6;
	public GameObject menu;
	public GameObject t;
	public GameObject f;

	public Ads adsScript;


	void Awake(){
		//Под первый запуск
		if (PlayerPrefs.GetInt ("FirstLaunch") != 1) {
			PlayerPrefs.SetInt ("FirstLaunch", 1);
			PlayerPrefs.SetInt ("Choose", 1);
			PlayerPrefs.SetInt ("Choos", 1);
			PlayerPrefs.SetInt ("Money", 0);
			PlayerPrefs.SetInt ("TLevel", 1);
			PlayerPrefs.SetInt ("FLevel", 1);
		}
		if (PlayerPrefs.GetString("Music") == "no")
		{   
			m_on.SetActive(false);
			m_off.SetActive(true);         
		}
		else
		{
			m_on.SetActive(true);
			m_off.SetActive(false);                
		}
	}
	void Start(){
		//PlayerPrefs.SetInt ("TLevel", 2);
		PlayerPrefs.SetInt ("Money", 1000);
		//PlayerPrefs.SetInt ("Choos", 1);
		PlayerPrefs.SetInt ("FLevel", 5);

		rund = Random.Range (1, 4);
		//Topor
		if (PlayerPrefs.GetInt ("TLevel") >= 1) {
			if (PlayerPrefs.GetInt ("Choose") == 1)
				fire.GetComponent<SpriteRenderer> ().sprite = oneT;
			tLock1.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("TLevel") >= 2) {
			if (PlayerPrefs.GetInt ("Choose") == 2)
				fire.GetComponent<SpriteRenderer> ().sprite = twoT;
			tLock2.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("TLevel") >= 3) {
			if (PlayerPrefs.GetInt ("Choose") == 3)
				fire.GetComponent<SpriteRenderer> ().sprite = threeT;
			tLock3.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("TLevel") >= 4) {
			if (PlayerPrefs.GetInt ("Choose") == 4)
				fire.GetComponent<SpriteRenderer> ().sprite = fourT;
			tLock4.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("TLevel") >= 5) {
			if (PlayerPrefs.GetInt ("Choose") == 5)
				fire.GetComponent<SpriteRenderer> ().sprite = fiveT;
			tLock5.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("TLevel") >= 6) {
			if (PlayerPrefs.GetInt ("Choose") == 6)
				fire.GetComponent<SpriteRenderer> ().sprite = sixT;
			tLock6.SetActive (false);
		}
		//Fon
		if (PlayerPrefs.GetInt ("FLevel") >= 1) {
			if (PlayerPrefs.GetInt ("Choos") == 1)
				menu.GetComponent<Image> ().sprite = oneF;
			fLock1.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("FLevel") >= 2) {
			if (PlayerPrefs.GetInt ("Choos") == 2)
				menu.GetComponent<Image> ().sprite = twoF;
			fLock2.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("FLevel") >= 3) {
			if (PlayerPrefs.GetInt ("Choos") == 3)
				menu.GetComponent<Image> ().sprite = threeF;
			fLock3.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("FLevel") >= 4) {
			if (PlayerPrefs.GetInt ("Choos") == 4)
				menu.GetComponent<Image> ().sprite = fourF;
			fLock4.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("FLevel") >= 5) {
			if (PlayerPrefs.GetInt ("Choos") == 5)
				menu.GetComponent<Image> ().sprite = fiveF;
			fLock5.SetActive (false);
		}
		if (PlayerPrefs.GetInt ("FLevel") >= 6) {
			if (PlayerPrefs.GetInt ("Choos") == 6)
				menu.GetComponent<Image> ().sprite = sixF;
			fLock6.SetActive (false);
		}
	}
	void Update(){
		money.text = PlayerPrefs.GetInt ("Money").ToString ();
		if (isStart) {
			//Запись счета очков
			scoreText.text = PlayerPrefs.GetInt ("Score").ToString ();
			//Создание новых объектов
			switch (rund) {
			case 1:
				if (visibleObject == null)
					visibleObject = Instantiate (oneObs, new Vector3 (5f, pos, transform.position.z), transform.rotation);
				break;
			case 2:
				if (visibleObject == null)
					visibleObject = Instantiate (twoObs, new Vector3 (5f, pos, transform.position.z), transform.rotation);
				break;
			case 3:
				if (visibleObject == null)
					visibleObject = Instantiate (threeObs, new Vector3 (5f, pos, transform.position.z), transform.rotation);
				break;
			}
		}
	}
	public void Music(){
		if (PlayerPrefs.GetString("Music") != "no")
		{
			PlayerPrefs.SetString("Music", "no");
			m_on.SetActive(false);
			m_off.SetActive(true);
			AudioListener.pause = true;
		}
		else
		{          
			PlayerPrefs.SetString("Music", "yes");                  
			m_on.SetActive(true);
			m_off.SetActive(false); 
			AudioListener.pause = false;
			GameObject.Find("Click").GetComponent<AudioSource>().Play();
		}
	}
	public void Click(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
	}
	public void StopPlaySound(){
		playSound.Stop ();
	}
	public void Ads(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		adsScript.StartCallBack ();
	}
	public void Shop(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
	}
	public void Main(){
		music.NoPlay ();
		ads.NoPlay ();
		shop.NoPlay ();
		records.NoPlay ();
		name.SetActive (true);
		play.SetActive (true);
		topor.SetActive (false);
		btnPlay1.NoBtn ();
		btnPlay2.NoBtn ();
		score.SetActive (false);
		fire.SetActive (true);
		isStart = false;
		playSound.Stop ();
		menuSound.Play ();
		gameover.Stop ();
		recordText.text = " ";
		notification.SetActive (false);
	}
	public void Play(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		//Смена сцены
		music.YesPlay ();
		ads.YesPlay ();
		shop.YesPlay ();
		records.YesPlay ();
		name.SetActive (false);
		play.SetActive (false);
		topor.SetActive (true);
		score.SetActive (true);
		fire.SetActive (true);
		isStart = true;
		PlayerPrefs.SetInt ("Score", 0);
		playSound.Play ();
		menuSound.Stop ();
	}
	public void Gameover(){
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("Record"))
			PlayerPrefs.SetInt ("Record", PlayerPrefs.GetInt ("Score"));
		btnPlay1.YesBtn ();
		btnPlay2.YesBtn ();
		fire.SetActive (false);
		Destroy (visibleObject);
		isStart = false;
		topor.SetActive (false);
		recordText.text = "< " + PlayerPrefs.GetInt ("Record").ToString() + " >";
		adsScript.StartInterstitial ();

		int topNow = (PlayerPrefs.GetInt("Score"));
		if (topNow >= PlayerPrefs.GetInt("Record")) {
			int[] mas = new int[50] {
				9909, 5305, 3043, 1043, 998, 850, 800, 740, 712, 650, 602, 593, 506, 479,  431, 302, 250,  201, 181, 169, 130, 129, 125, 115, 105, 101, 99, 92, 81, 84, 78, 75, 70, 69, 61, 59, 55, 50, 47, 45, 40, 36, 30, 26, 25, 21, 15, 10, 5,
				topNow
			};

			//Сортировка массива
			for (int i = 0; i < 50 - 1; i++) {
				for (int j = 0; j < 50 - 1; j++) {
					if (mas [j] < mas [j + 1]) {
						int tmp = mas [j];
						mas [j] = mas [j + 1];
						mas [j + 1] = tmp;
					}
				}
			}

			for (int i = 0; i < 50 - 1; i++) {
				if (mas [i] == topNow) {
					int topPosition = i + 1;
					top.text = "Вы на " + topPosition.ToString () + " месте" + "\r" + " в топе";
					notification.SetActive (true);
				}
			}
		}
	}
	public void Replay(){
		Main ();
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
	}
	public void Records(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		recordPanel.SetActive (true);
		fire.SetActive (false);
	}
	public void Reviews(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.newsgames.topor");
	}
	public void Topor(){
		animFire.Fire ();
		rund = Random.Range(1, 4);
		pos = Random.Range(0, 3);
	}
	public void Fons(){
		t.SetActive (false);
		f.SetActive (true);
	}
	public void Topors(){
		t.SetActive (true);
		f.SetActive (false);
	}
	public void OneT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 1) {
			PlayerPrefs.SetInt ("Choose", 1);
			fire.GetComponent<SpriteRenderer>().sprite = oneT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
				PlayerPrefs.SetInt ("TLevel", 1);
				PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
				tLock1.SetActive (false);
				fire.GetComponent<SpriteRenderer>().sprite = oneT;
				GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
			}
		}
	}
	public void TwoT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 2) {
			PlayerPrefs.SetInt ("Choose", 2);
			fire.GetComponent<SpriteRenderer>().sprite = twoT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("TLevel") == 1) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("TLevel", 2);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					tLock2.SetActive (false);
					fire.GetComponent<SpriteRenderer> ().sprite = twoT;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void ThreeT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 3) {
			PlayerPrefs.SetInt ("Choose", 3);
			fire.GetComponent<SpriteRenderer>().sprite = threeT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("TLevel") == 2) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("TLevel", 3);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					tLock3.SetActive (false);
					fire.GetComponent<SpriteRenderer> ().sprite = threeT;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void FourT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 4) {
			PlayerPrefs.SetInt ("Choose", 4);
			fire.GetComponent<SpriteRenderer>().sprite = fourT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("TLevel") == 3) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("TLevel", 4);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					tLock4.SetActive (false);
					fire.GetComponent<SpriteRenderer> ().sprite = fourT;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void FiveT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 5) {
			PlayerPrefs.SetInt ("Choose", 5);
			fire.GetComponent<SpriteRenderer>().sprite = fiveT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("TLevel") == 4) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("TLevel", 5);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					tLock5.SetActive (false);
					fire.GetComponent<SpriteRenderer> ().sprite = fiveT;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void SixT(){
		if (PlayerPrefs.GetInt ("TLevel") >= 6) {
			PlayerPrefs.SetInt ("Choose", 6);
			fire.GetComponent<SpriteRenderer>().sprite = sixT;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("TLevel") == 5) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("TLevel", 6);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					tLock6.SetActive (false);
					fire.GetComponent<SpriteRenderer> ().sprite = sixT;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void OneF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 1) {
			PlayerPrefs.SetInt ("Choos", 1);
			menu.GetComponent<Image> ().sprite = oneF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
				PlayerPrefs.SetInt ("FLevel", 1);
				PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
				fLock1.SetActive (false);
				menu.GetComponent<Image> ().sprite = oneF;
				GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
			}
		}
	}
	public void TwoF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 2) {
			PlayerPrefs.SetInt ("Choos", 2);
			menu.GetComponent<Image> ().sprite = twoF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("FLevel") == 1) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("FLevel", 2);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					fLock2.SetActive (false);
					menu.GetComponent<Image> ().sprite = twoF;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void ThreeF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 3) {
			PlayerPrefs.SetInt ("Choos", 3);
			menu.GetComponent<Image> ().sprite = threeF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("FLevel") == 2) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("FLevel", 3);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					fLock3.SetActive (false);
					menu.GetComponent<Image> ().sprite = threeF;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void FourF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 4) {
			PlayerPrefs.SetInt ("Choos", 4);
			menu.GetComponent<Image> ().sprite = fourF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("FLevel") == 3) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("FLevel", 4);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					fLock4.SetActive (false);
					menu.GetComponent<Image> ().sprite = fourF;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void FiveF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 5) {
			PlayerPrefs.SetInt ("Choos", 5);
			menu.GetComponent<Image> ().sprite = fiveF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("FLevel") == 4) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("FLevel", 5);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					fLock5.SetActive (false);
					menu.GetComponent<Image> ().sprite = fiveF;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
	public void SixF(){
		if (PlayerPrefs.GetInt ("FLevel") >= 6) {
			PlayerPrefs.SetInt ("Choos", 6);
			menu.GetComponent<Image> ().sprite = sixF;
			//Галочка выбора
		} else {
			if (PlayerPrefs.GetInt ("FLevel") == 5) {
				if (PlayerPrefs.GetInt ("Money") >= shopMoney) {
					PlayerPrefs.SetInt ("FLevel", 6);
					PlayerPrefs.SetInt ("Money", PlayerPrefs.GetInt ("Money") - shopMoney);
					fLock6.SetActive (false);
					menu.GetComponent<Image> ().sprite = sixF;
					GameObject.Find ("Coin").GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}
}
