using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public Player player;
	private Vector2 playerPos;
	public bool onDrag = false;

	void Awake () {
		playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
	}
			
	void Update () {
		if (onDrag == true) {
			if (this.transform.position.x < playerPos.x) {
				this.transform.position = new Vector2 (playerPos.x + 10.0f, playerPos.y);
			} else if (this.transform.position.x > playerPos.y) {
				this.transform.position = new Vector2 (playerPos.x - 10.0f, playerPos.y); 
			}
		} 
		else {
			//this.transform.position.Set;
		}
	}
}
