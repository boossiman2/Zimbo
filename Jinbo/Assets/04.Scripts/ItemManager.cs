using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public float immortalTime = 3.0f;
	public float bossDelayTime = PlayerPrefs.GetFloat("DelayTime", 10.0f);
	public BossMonster bossMonster;
	private int coin = 0;

	void Start () {
		coin = PlayerPrefs.GetInt ("Coin", 0);
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if (this.name.Equals ("Coin") && col.name.Equals ("Player")) { // 코인 획득
			Destroy (this.gameObject);
			coin += 1;
			Debug.Log ("Coin +1");
		} else if (this.name.Equals ("Sword") && col.name.Equals ("Player")) { // 칼 획득
			PlayerMgr.instance.Equipped();
			Destroy(this.gameObject);
		} else if (this.name.Equals ("Immortal") && col.name.Equals ("Player")) {
			StartCoroutine (GetImmortal ());
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else if (this.name.Equals ("Slow") && col.name.Equals ("Player")) {
			bossMonster.Slow (bossDelayTime);
		}
    }	

	public IEnumerator GetImmortal() {
		//player.state = "Immortal";
		Debug.Log("무적시작");
		PlayerMgr.instance._spec = PlayerMgr.playerSpec.immortal;
		yield return new WaitForSeconds(immortalTime);
		//Player.state = "Normal"
		Debug.Log("무적끝");
		PlayerMgr.instance._spec = PlayerMgr.playerSpec.normal;
		Destroy (this.gameObject);
	}
}