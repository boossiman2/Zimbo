using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainSceneMgr : MonoBehaviour {
	public UnityEngine.UI.Image fade;
	public GameObject Panel;
	public GameObject bgm;
	public GameObject credit;
	float fades = 1.0f;
	float time = 0;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (bgm);
	}

	void Update()
	{
		time += Time.deltaTime;
		if (fades > 0.0f && time >= 0.1f) {
			fades -= 0.01f;
			fade.color = new Color (0, 0, 0, fades);

		} else if (fades <= 0.0f) {
			Panel.SetActive (false);
			if (Application.platform == RuntimePlatform.Android) {
				if (Input.GetKey (KeyCode.Escape)) {

					Application.Quit ();
				}
			}
		}


	}
	// Update is called once per frame
	public void OnClickStartBtn(){
		SceneManager.LoadScene ("Ready");
		
	}
	public void OnClickExitBtn(){
		Application.Quit ();
	}

	public void PlayOneSound(AudioClip ac){
		AudioSource.PlayClipAtPoint (ac, this.transform.position);
	}

	public void OnClickLogo(){
		credit.SetActive (true);
	}

	public void OnClickCredit(){
		credit.SetActive (false);
	}
}
