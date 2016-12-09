using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	int coin = 0;

	void Start () {
		coin = PlayerPrefs.GetInt ("Coin", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
