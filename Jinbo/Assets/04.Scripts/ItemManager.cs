using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	public float immortalTime = 3.0f;
	public float bossDelayTime = 10.0f;
	public BossMonster bossMonster;
	private int coin = 0;

	void Start () {
		bossDelayTime = PlayerPrefs.GetFloat ("DurationStatus", 10.0f);
		coin = PlayerPrefs.GetInt ("Coin", 0);
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if (this.tag.Equals("Coin") && col.name=="Player") { // 코인 획득
			Destroy (this.gameObject);
			coin += 1;
			PlayerPrefs.SetInt ("Coin", coin);

		} else if (this.name.Equals ("Sword") && col.name.Equals ("Player")) { // 칼 획득
			PlayerMgr.instance.Equipped();
			Destroy(this.gameObject);
		} else if (this.name.Equals ("Immortal") && col.name.Equals ("Player")) {
			Debug.Log ("충돌");
			StartCoroutine (GetImmortal ());
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else if (this.name.Equals ("Slow") && col.name.Equals ("Player")) {
			bossMonster.Slow (bossDelayTime);
		}
    }	

	public IEnumerator GetImmortal() {
		PlayerMgr.instance._spec = PlayerMgr.playerSpec.immortal;
		yield return new WaitForSeconds(immortalTime);
		PlayerMgr.instance._spec = PlayerMgr.playerSpec.normal;
		Destroy (this.gameObject);
	}
}