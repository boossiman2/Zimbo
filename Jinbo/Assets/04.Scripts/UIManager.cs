using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text tvCoin;


	void Update () {
		tvCoin.text = PlayerPrefs.GetInt ("Coin", 0) + "";
	}

}
