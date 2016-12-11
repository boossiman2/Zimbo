using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {

	public GameObject coin;
	Vector3 pos;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range (1, 50); i++) {
			pos = this.transform.position + Vector3.right*Random.Range(0.0f,100.0f);
			Instantiate(coin,pos, this.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
