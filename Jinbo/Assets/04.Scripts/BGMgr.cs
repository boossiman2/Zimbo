using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMgr : MonoBehaviour {
	public GameObject[] bgImg;
	public int currIdx=1;
	public float moveOffset;
	// Use this for initialization
	void Start () {
		SpriteRenderer[] bgBack = bgImg [0].GetComponentsInChildren<SpriteRenderer> ();
		float spWidth = 0.0f;	
		foreach (var sp in bgBack) {
			//spWidth += 17.92;
		}
		moveOffset = spWidth;
	}
	
	// Update is called once per frame
	public void ChangeBg(){
		bgImg [currIdx].transform.position += new Vector3 (moveOffset * 2, 0, 0);
		currIdx = ++currIdx % 4;
	}
}
