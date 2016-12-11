using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyManager : MonoBehaviour {

	public ReadyUIManager uiManager;
	public Text tvCoin;

	int coin;
	int runLevel;
	int jumpLevel;
	int durationLevel;

	float runStatus;
	float jumpStatus;
	float durationStatus;

	void Start () {
		//초기화 및 할당
		coin = PlayerPrefs.GetInt ("Coin", 0);
		runLevel = PlayerPrefs.GetInt ("RunLevel", 1);
		jumpLevel = PlayerPrefs.GetInt ("JumpLevel", 1);
		durationLevel = PlayerPrefs.GetInt ("DurationLevel", 1);

		runStatus = PlayerPrefs.GetFloat ("RunStatus", 2.0f);
		jumpStatus = PlayerPrefs.GetFloat ("JumpStatus", 600.0f);
		durationStatus = PlayerPrefs.GetFloat ("DurationStatus", 10.0f);

		//UI Manager
	}

	void Update () {
		tvCoin.text = coin + " G";
		uiManager.SetRunLevel (runLevel);
		uiManager.SetJumpLevel (jumpLevel);
		uiManager.SetDurationLevel (durationLevel);
		uiManager.SetRunPrice ((int)Mathf.Pow (2, (runLevel + 3)));
		uiManager.SetJumpPrice((int)Mathf.Pow (2, (jumpLevel + 3)));
		uiManager.SetDurationPrice((int)Mathf.Pow (2, (durationLevel + 3)));


		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {

				SceneManager.LoadScene ("Main");
			}
		}
	}

	public void BuyRunItem(){
		if (coin >= (int)Mathf.Pow(2,(runLevel+3))) {
			coin -= (int)Mathf.Pow(2,(runLevel+3)); //Minus coin (구입)
			runLevel++;
			runStatus += 0.1f;
			PlayerPrefs.SetInt ("RunLevel", runLevel);
			PlayerPrefs.SetFloat ("RunStatus", runStatus);
			//uiManager.SetRunLevel (runLevel);
			//uiManager.SetRunPrice((int)Mathf.Pow(2,(runLevel+3)));
		}
		else { Debug.Log ("골드부족");}
	}

	public void BuyJumpItem(){
		if (coin >= (int)Mathf.Pow(2,(jumpLevel+3))) {
			coin -= (int)Mathf.Pow(2,(jumpLevel+3)); //Minus coin (구입)
			jumpLevel++;
			jumpStatus += 5.0f;
			PlayerPrefs.SetInt ("JumpLevel", jumpLevel);
			PlayerPrefs.SetFloat ("JumpStatus", jumpStatus);
			//uiManager.SetJumpLevel (jumpLevel);
			//uiManager.SetRunPrice((int)Mathf.Pow(2,(jumpLevel+3)));
		}
		else { Debug.Log ("골드부족");}
	}

	public void BuyDurationItem() {
		if (coin >= (int)Mathf.Pow(2,(durationLevel+3))) {
			coin -= (int)Mathf.Pow(2,(durationLevel+3)); //Minus coin (구입)
			durationLevel++;
			durationStatus += 1.0f;
			PlayerPrefs.SetInt ("DurationLevel", durationLevel);
			PlayerPrefs.SetFloat ("DurationStatus", durationStatus);
			//uiManager.SetDurationLevel (durationLevel);
			//uiManager.SetRunPrice((int)Mathf.Pow(2,(durationLevel+3)));
		}
		else { Debug.Log ("골드부족");}
	}


	public void PlayOneSound(AudioClip ac){
		AudioSource.PlayClipAtPoint (ac, this.transform.position);
	}

	public void OnClickStartBtn(){
		SceneManager.LoadScene ("Stage1");
	}
	public void OnClickLogo(){
		SceneManager.LoadScene ("Main");
	}
}
