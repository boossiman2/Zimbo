using UnityEngine;
using System.Collections;
public class Bat : MonoBehaviour
{
    public float speed = 18.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Destroy(this, 25.0f);
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Equals ("Player")) { // 플레이어와 충돌한 경우
			if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.immortal) { // 플레이어 현재 상태가 무적이면
				Destroy(this.gameObject);
			} else if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.normal) { // 플레이어 현재 상태가 정상이면
				PlayerMgr.instance._state = PlayerMgr.playerState.dead;
			}
		} 
		else if (col.name.Equals ("Sword")) {
		}
	}
}
