using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedSceneMgr : MonoBehaviour {
	public AudioClip ac;

	public UnityEngine.UI.Image fade;
	public GameObject Panel;
	float fades = 1.0f;
	float time = 0;

	// Use this for initialization
	void Start () {
		PlayOneSound (ac);
		MapTileManager.FlowerCountReset ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (fades > 0.0f && time >= 0.1f) {
			fades -= 0.01f;
			fade.color = new Color (0, 0, 0, fades);

		} else if (fades <= 0.0f) {
			Panel.SetActive (false);
		}
	}

	public void OnClickRetryBtn(){
		SceneManager.LoadScene ("Stage1");
	}
	public void OnClickExitBtn(){
		SceneManager.LoadScene ("Main");
	}

	public void PlayOneSound(AudioClip ac){
		AudioSource.PlayClipAtPoint (ac, this.transform.position);
	}
}
