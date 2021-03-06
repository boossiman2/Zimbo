﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 5.0f);
	}

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Equals ("Player")) { // 플레이어와 충돌한 경우

			if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.immortal) { // 플레이어 현재 상태가 무적이면
				Destroy(this.gameObject);
			} else if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.normal) { // 플레이어 현재 상태가 정상이면
				PlayerMgr.instance.isGameover = true;
			}
		} 
     }
}