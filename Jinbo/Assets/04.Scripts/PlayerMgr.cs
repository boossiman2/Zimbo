using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMgr : MonoBehaviour {
	public static PlayerMgr instance;

	public static PlayerMgr _instance {
		get {
			return instance;
		}
		set {
			value = instance;
		}
	}

	public enum playerState{	
		idle = 0,
		walk,
		attack,
		dead,
		push
	}
	public enum playerSpec{
		normal = 0,
		immortal
	}
	public Animator anim;
	public playerState _state = playerState.idle;	
	public playerSpec _spec =playerSpec.normal;
	public Button AttackBtn;
	public GameObject JBtn;
	public GameObject ABtn;
	public GameObject GBtn;

	private Transform tr;
	private Rigidbody2D rb;
	private SpriteRenderer sp;

	public float moveSpeed = PlayerPrefs.GetFloat("RunStatus", 2.5f);
	public float jumpSpeed = PlayerPrefs.GetFloat("JumpStatus", 600.0f);

	public float h = 0.0f;

	private Vector2 gtopLeftPoint;
	private Vector2 gBottomRightPoint;

	private Vector2 mtopLeftPoint;
	private Vector2 mBottomRightPoint;

	private bool isJump = false;
	private bool isFall = false;
	private bool isWalk = false;
	private bool isAttack = false;
	private bool isDrag = false;
	public bool isGameover = false;
	public Vector2 direction;

	private Vector3 mousePos;

	bool bEquip_sword =  false;
	public AnimatorOverrideController aoc;
	public GameObject smgr;




	public AudioClip jumpSound;
	public AudioClip landSound; 
	//public AudioClip moveSound; 
	public AudioClip diedSound;
	public AudioClip attackSound;





	//bool isLeftCheck;
	//bool isRightCheck;

	void Awake() {
		smgr = GameObject.Find ("SoundMgr");
		Destroy (smgr);
		instance = this;

	}

	// Use this for initialization
	void Start () {

		tr = transform;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sp = GetComponent<SpriteRenderer> ();
		jumpSound = (AudioClip)Resources.Load("Sound/LandingFromJump01");
		//landSound = (AudioClip)Resources.Load("Sound/LandingFromJump02");
		//moveSound = (AudioClip)Resources.Load("Sound/Move");
		diedSound = (AudioClip)Resources.Load("Sound/Died");
		attackSound = (AudioClip)Resources.Load("Sound/Attack");

	}

	void Update(){
		IsFall ();
		if (isGameover) {
			anim.SetBool ("isDead", true);
			SceneManager.LoadScene ("Died");

		}
		IsPush ();
		if (IsFrontMovableObject()) {
			GBtn.SetActive (true);
		} else {
			GBtn.SetActive (false);
		}

		direction = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical"));

		if (isAttack) {
			_state = playerState.attack;
			anim.SetInteger ("playerState", (int)_state);
			PlaySoundClip (attackSound);
			isAttack = false;
		}
		else if(IsWalk()){
			rb.velocity = new Vector3 (moveSpeed*h, rb.velocity.y);
		}


		//캐릭터 애니메이션 변경
		if (anim != null) {
			anim.SetInteger ("playerState", (int)_state);
			Debug.Log (_state);
			if (rb.velocity.y > 0.0f&&!IsGrounded()) {
				anim.SetBool ("isJump", true);

			} else if (rb.velocity.y < 0.0f&&!IsGrounded()) {
				anim.SetBool ("isJump", false);
				anim.SetBool ("isFall", true);
			} else if (rb.velocity.y == 0.0f) {
				anim.SetBool ("isJump", false);
				anim.SetBool ("isFall", false);

			}

		}

		if (_state == playerState.dead) {
			Debug.Log ("게임오버");
		}

	}


	bool IsGrounded(){
		
		gtopLeftPoint = new Vector2 (tr.position.x - 0.3f, tr.position.y-0.6f);
		gBottomRightPoint = new Vector2 (tr.position.x + 0.2f, tr.position.y - 0.8f);
		var hit = Physics2D.OverlapArea (gtopLeftPoint, gBottomRightPoint, 1 << 9);
		return(hit != null);
	}

	bool IsFrontMonster(){

		mtopLeftPoint = new Vector2 (transform.position.x + 0.2f, transform.position.y+0.6f);
		mBottomRightPoint = new Vector2 (transform.position.x + 0.9f, transform.position.y - 0.6f);
		var hit = Physics2D.OverlapArea (mtopLeftPoint, mBottomRightPoint, 1 << 11);
		return(hit != null);
	}

	bool IsFrontMovableObject(){
		mtopLeftPoint = new Vector2 (transform.position.x + 0.2f, transform.position.y+0.6f);
		mBottomRightPoint = new Vector2 (transform.position.x + 0.9f, transform.position.y - 0.6f);
		var hit = Physics2D.OverlapArea (mtopLeftPoint, mBottomRightPoint, 1 << 10);
		return(hit != null);
	}

	bool IsWalk(){

		if (h != 0) {
			if (IsPush()) {
				h = h * 0.4f;
				_state = playerState.push;
			}
			else {
				
				if (h < 0)
					sp.flipX = true;
				else
					sp.flipX = false;
				
				_state = playerState.walk;
				//PlaySoundClip (moveSound);
			}
			return true;
		} else if (isGameover) {
			return false;
		}else{

			_state = playerState.idle;
			return false;
		}
	}

	void OnDrawGizmos(){
		#if UNITY_EDITOR
		gtopLeftPoint = new Vector2(transform.position.x - 0.3f, transform.position.y-0.6f);
		gBottomRightPoint = new Vector2 (transform.position.x + 0.2f, transform.position.y - 0.8f);

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(gtopLeftPoint, 0.1f);
		Gizmos.DrawWireSphere(gBottomRightPoint, 0.1f);


		mtopLeftPoint = new Vector2(transform.position.x + 0.2f, transform.position.y+0.6f);
		mBottomRightPoint = new Vector2 (transform.position.x + 0.9f, transform.position.y - 0.6f);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(mtopLeftPoint, 0.1f);
		Gizmos.DrawWireSphere(mBottomRightPoint, 0.1f);
		#endif

	}

	public void Equipped(){
		if (bEquip_sword == false) {
			bEquip_sword = true;
			anim.runtimeAnimatorController = aoc;
			ABtn.SetActive (true);

		}

		//장착 시 공격

	}

	public void RightDown(){
		h = 1.0f;
		Debug.Log ("오");

	}

	public void LeftDown(){
		Debug.Log ("왼");
		h = -1.0f;
	}

	public void ButtonUp(){
		h = 0.0f;
	}

	public void ActionButton(){
		Equipped ();
		if (bEquip_sword) {
			Attack ();
		}

	}
	public void JumpButton(){

		if (IsGrounded ()) {
			Debug.Log ("ground");
			isJump = true;
			rb.AddForce (Vector2.up * jumpSpeed);
			PlaySoundClip (jumpSound);

		} else 
			isJump = false;
	}

	public Vector2 getDirection(){
		return direction;
	}
	public Vector3 getPosition(){
		return transform.position;
	}

	public void Attack(){
	

		if (isAttack) {
			Debug.Log ("공격중");
			return;
		}
		
		Debug.Log ("공격");
		isAttack = true;
		anim.SetBool ("isAttack", isAttack);
		Invoke ("AttackBtnEnable",0.1f);
		
	}
	void AttackBtnEnable(){
		Debug.Log ("액션버튼");
		AttackBtn.enabled = true;
	}
	bool IsPush(){
		if (this.transform.childCount == 0) {
			JBtn.SetActive (true);
			return false;
		} else
			JBtn.SetActive (false);
			return true;
	}
	public void PlaySoundClip(AudioClip ac){
		AudioSource.PlayClipAtPoint (ac, this.transform.position);
	}

	public bool IsFall(){
		if (this.transform.position.y < -3) {
			isGameover = true;
			return true;
		}
		else
			return false;

	}

	public void OnTriggerEnter2D(Collider2D col) {
		if(col.name.Equals("flower")){
			MapTileManager.FlowerCount ();
			if (SceneManager.GetActiveScene ().name == "Stage1") {
				GameSceneManager.ChangeScene ("Stage2");
			}
			if (SceneManager.GetActiveScene ().name == "Stage2") {
				GameSceneManager.ChangeScene ("Stage3");
			}
			if (SceneManager.GetActiveScene ().name == "Stage3") {
				GameSceneManager.ChangeScene ("Stage4");
			}
			if (SceneManager.GetActiveScene ().name == "Stage4") {
				GameSceneManager.ChangeScene ("Stage5");
			}
			if (SceneManager.GetActiveScene ().name == "Stage5") {
				GameSceneManager.ChangeScene ("Stage6");
			}
			if (SceneManager.GetActiveScene ().name == "Stage6") {
				GameSceneManager.ChangeScene ("Died");
			}

		}
	}


}
 