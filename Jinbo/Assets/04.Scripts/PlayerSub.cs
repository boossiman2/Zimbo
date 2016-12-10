using UnityEngine;
using System.Collections;

public class PlayerSub :MonoBehaviour {

	private Vector2 direction;
	public enum state {
		Normal, Immortal, Die
	};

	void Update() {
		direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		transform.Translate(direction * Time.deltaTime);

		if (state == Die) {
			Debug.Log ("게임오버");
			//gameover
		}
	}
		
	public Vector2 getDirection() {
		return direction;
	}

	public Vector3 getPosition() {
		return transform.position;
	}
}