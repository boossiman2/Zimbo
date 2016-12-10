using System.Collections;
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
	private bool isAttack = false;

	private Vector3 mousePos;

	bool bEquip_sword =  false;
	public AnimatorOverrideController aoc;

	//bool isLeftCheck;
	//bool isRightCheck;


	// Use this for initialization
	void Start () {

		tr = transform;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();


	}

	void Update(){


	

		if (isAttack) {
			_state = playerState.attack;
			isAttack = false;
			//StartCoroutine (StopAttack ());
			//Debug.Log ("이즈어택공격");

		}

		else if(IsWalk()){
			rb.velocity = new Vector3 (moveSpeed*h, rb.velocity.y);
		}


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

	}


	bool IsGrounded(){
		
		topLeftPoint = new Vector2 (tr.position.x - 0.3f, tr.position.y-0.6f);
		BottomRightPoint = new Vector2 (tr.position.x + 0.2f, tr.position.y - 0.8f);
		var hit = Physics2D.OverlapArea (topLeftPoint, BottomRightPoint, 1 << 9);
		return(hit != null);
	}

	bool IsWalk(){

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
		topLeftPoint = new Vector2(transform.position.x - 0.3f, transform.position.y-0.6f);
		BottomRightPoint = new Vector2 (transform.position.x + 0.2f, transform.position.y - 0.8f);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(topLeftPoint, 0.1f);
		Gizmos.DrawWireSphere(BottomRightPoint, 0.1f);
		#endif

	}

	public void Equipped(){
		if (bEquip_sword == false) {
			bEquip_sword = true;
			anim.runtimeAnimatorController = aoc;
		}
		else{
			if (isAttack) {
				return;
			}
			//_state = playerState.attack;
			Debug.Log ("공격");
			isAttack = true;
			//StartCoroutine (Attcking ());

		}
		//장착 시 공격

	}

	public void RightDown(){
		h = 1.0f;

	}

	public void LeftDown(){
		h = -1.0f;
	}

	public void ButtonUp(){
		h = 0.0f;
	}

	public void ActionButton(){
		Equipped ();

	}
	public void JumpButton(){

		if (IsGrounded ()) {
			Debug.Log ("ground");
			isJump = true;
			rb.AddForce (Vector2.up * jumpSpeed);

		} else 
			isJump = false;
	}

	//IEnumerator StopAttack(){
	//	yield return new WaitForSecondsRealtime (0.6f);
	//	isAttack = false;
	//
	//}
	
}
 