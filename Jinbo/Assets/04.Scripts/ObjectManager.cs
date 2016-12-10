using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	private GameObject player;
	private Vector2 playerPos;
	public bool onDrag = false;

	void Awake () {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
			
	void Update () {
		if (onDrag == true) {
			if (this.transform.position.x > playerPos.x) {
				transform.parent = player.transform; } 
			else if (this.transform.position.x < playerPos.y) {
				transform.parent = player.transform; }
		} 
		else {
			transform.parent = null; }
	}
}
