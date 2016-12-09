using UnityEngine;
using System.Collections;

public class Player :MonoBehaviour {

	public float speed = 3;

	protected Animator animator;
	private Vector2 direction;

	// NOTE: 컴퓨터에서 테스트 하기 위해 방향키로 조작하기 위해서는 false, 모바일에서 터치패드 이용 가능하게 하려면 true.
	public bool useTouchPad = false;

	void Start() {
		animator = GetComponent<Animator>();
	}

	void Update() {
		if (!useTouchPad) {
			direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}

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