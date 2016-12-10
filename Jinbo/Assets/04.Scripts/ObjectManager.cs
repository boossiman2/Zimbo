using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	private GameObject player;
	private Vector3 playerPos;
	public bool onDrag = false;

	void Awake () {
		//playerPos = new Vector2 (PlayerMgr.instance.getPosition().x, PlayerMgr.instance.getPosition().y);
		player = GameObject.FindGameObjectWithTag ("Player");
		playerPos = player.GetComponent<Transform> ().position;

	}
			
	void Update () {
		if (onDrag) {
			Debug.Log ("온드래그 true");
			if (this.transform.position.x > playerPos.x) {
				transform.parent = player.transform; } 
			else if (this.transform.position.x < playerPos.y) {
				transform.parent = player.transform; }
		} 
		else {
			Debug.Log ("온드래그 false");
			transform.parent = null; 
		}
	}
}
