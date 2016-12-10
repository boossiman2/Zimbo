using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public PlayerMgr player;
	private Vector2 playerPos;
	public bool onDrag = false;

	void Awake () {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;	}
			
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
