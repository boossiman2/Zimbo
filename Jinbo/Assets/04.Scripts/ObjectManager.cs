using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public PlayerMgr player;
	private Vector3 playerPos;
	public bool onDrag;
	public float fDist = 0.0f;

	void Awake () {
		//playerPos = new Vector2 (PlayerMgr.instance.getPosition().x, PlayerMgr.instance.getPosition().y);
		//player = GameObject.FindGameObjectWithTag ("Player");
		//playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
		playerPos = player.transform.position;
		onDrag = false;
	}
			
	void Update () {
		if (onDrag == true) {
			Debug.Log ("하이!");
			this.transform.parent = player.transform;

			if (fDist == 0)
				fDist = this.transform.position.x - player.getPosition ().x;
			else
				this.transform.position = player.getPosition()+ new Vector3(fDist, 0.0f,0.0f);
			
		
			
		}
		else {
			Debug.Log ("헬로");
			transform.parent = null; 
			fDist = 0.0f;
		}
	}


}
