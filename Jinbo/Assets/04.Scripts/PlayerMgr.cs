using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMgr : MonoBehaviour {

	public enum playerState{	
		idle = 0,
		walk,
		attack,
		dead
	}
	public Animator anim;
	public playerState _state = playerState.idle;


	private Transform tr;
	private Rigidbody2D rb;
	private SpriteRenderer sp;

	public float moveSpeed = 100.0f;
	public float jumpSpeed = 600.0f;

	private float h = 0.0f;

	private Vector2 topLeftPoint;
	private Vector2 BottomRightPoint;

	private bool isJump = false;
	private bool isFall = false;
	private bool isWalk = false;

	private Vector3 mousePos;


	// Use this for initialization
	void Start () {

		tr = transform;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();

	}
	void FixedUpdate () {

		//점프
		if (isJump) {
			Debug.Log ("JUMP");
			rb.AddForce (Vector2.up * jumpSpeed);
			isJump = false;
		}
		//이동
		if (IsWalk()) {
			rb.velocity = new Vector3 (moveSpeed*h, rb.velocity.y);
		}


	}

	void Update(){
		

		//캐릭터 애니메이션 변경
		if (anim != null) {
			anim.SetInteger ("playerState", (int)_state);
			if (rb.velocity.y > 0.0f) {
				anim.SetBool ("isJump", true);
			} else if (rb.velocity.y < 0.0f) {
				anim.SetBool ("isJump", false);
				anim.SetBool ("isFall", true);
			} else if (rb.velocity.y == 0.0f) {
				anim.SetBool ("isJump", false);
				anim.SetBool ("isFall", false);
			}

		}

		//스페이스 누를 시 점프
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Space)&&IsGrounded ()) {
			Debug.Log ("ground");
			isJump = true;
		} else 
			isJump = false;
		#endif

		#if UNITY_ANDROID || UNITY_IPHONE
		/*
		if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began && IsGrounded()){
			isJump = true;
		}else{
			isJump = false;
		}
		*/
		#endif
	}


	bool IsGrounded(){
		
		topLeftPoint = new Vector2 (tr.position.x - 0.5f, tr.position.y-1.0f);
		BottomRightPoint = new Vector2 (tr.position.x + 0.5f, tr.position.y - 1.3f);

		var hit = Physics2D.OverlapArea (topLeftPoint, BottomRightPoint, 1 << 9);
		return(hit != null);
	}

	bool IsWalk(){
		#if UNITY_EDITOR
		h = Input.GetAxisRaw ("Horizontal");
		#endif

		/*if (Input.GetMouseButton (1)) {
			h = 1.0f;
		} else if (Input.GetMouseButton (0)) {
			h = -1.0f;
		} else
			h = 0.0f;
		*/

		if (h != 0) {
			if (h < 0)
				sp.flipX = true;
			else
				sp.flipX = false;
			_state = playerState.walk;
			return true;
		} else {
			_state = playerState.idle;
			return false;
		}
	}

	void OnDrawGizmos(){
		#if UNITY_EDITOR
		topLeftPoint = new Vector2(transform.position.x - 0.5f, transform.position.y-1.0f);
		BottomRightPoint = new Vector2 (transform.position.x + 0.5f, transform.position.y - 1.3f);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(topLeftPoint, 0.1f);
		Gizmos.DrawWireSphere(BottomRightPoint, 0.1f);
		#endif

	}

	public void OnLButtonClick(){

	}

	public void OnRButtonClick(){
		
	}




}
 