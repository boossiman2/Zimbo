using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyUIManager : MonoBehaviour {

	public Text runItemLevel;
	public Text runItemPrice;
	public Image runItemImage;

	public Text jumpItemLevel;
	public Text jumpItemPrice;
	public Image jumpItemImage;

	public Text durationItemLevel;
	public Text durationItemPrice;
	public Image durationItemImage;

	void Start(){

	}

	public void SetRunLevel(float level) {
		runItemLevel.text = "Level " + level;
	}

	public void SetJumpLevel(float level) {
		jumpItemLevel.text = "Level " + level;
	}

	public void SetDurationLevel(float level) {
		durationItemLevel.text = "Level " + level;
	}

	public void SetRunPrice(int price) {
		runItemPrice.text = price + " G";
	}

	public void SetJumpPrice(int price) {
		jumpItemPrice.text = price + " G";
	}

	public void SetDurationPrice(int price) {
		durationItemPrice.text = price + " G";
	}

	public void OnClickStartBtn(){
		SceneManager.LoadScene ("Stage1");
	}
}
