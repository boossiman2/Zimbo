using UnityEngine;
using System.Collections;

public class Player :MonoBehaviour {

	private Vector2 direction;

	void Start() {
	}

	void Update(){
		direction = new Vector2(0, Input.GetAxis("Vertical"));
		transform.Translate(direction * Time.deltaTime);
	}

	public void setDirection(Vector2 dir)
	{
		direction = dir;
	}

	public Vector2 getDirection() {
		return direction;
	}

	public Vector3 getPosition() {
		return transform.position;
	}
}