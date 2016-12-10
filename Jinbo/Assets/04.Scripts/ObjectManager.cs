using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public PlayerSub playerSub;
	private Vector2 playerPos;
	public bool onDrag = false;

	void Awake () {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;	}
			
	void Update () {
		if (onDrag == true) {
			if (this.transform.position.x > playerPos.x) {
				transform.parent = playerSub.transform; } 
			else if (this.transform.position.x < playerPos.y) {
				transform.parent = playerSub.transform; }
		} 
		else {
			transform.parent = null; }
	}
}
