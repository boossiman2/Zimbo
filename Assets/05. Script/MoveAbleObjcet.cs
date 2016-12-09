using UnityEngine;
using System.Collections;

public class MoveableObjcet : MonoBehaviour {

	//public Player player;
	private Vector2 playerPos;
	public bool onDrag = false;

	void Awake () {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
	}
			
	void Update () {
		if (onDrag == true) {
		    this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos, 0.1f);
		}
	}
}
