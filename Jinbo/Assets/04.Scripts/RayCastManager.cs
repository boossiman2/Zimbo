using UnityEngine;
using System.Collections;

public class RayCastManager :MonoBehaviour {

	public string DO_SEARCH = "조사/행동";
	public string DO_OK = "확인";
	private bool isCancelable = false;

	public ObjectManager Drag;
	private Collider2D col;

	public void ClickDoButton() {
		if (isCancelable) {
			isCancelable = false;
			Drag.onDrag = false;
			if (col != null) {
				col.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
			}
			return;
		}

		// Background 레이어를 제외한 것을 탐색
		Vector2 vec2 = new Vector2(PlayerMgr.instance.h,0.0f);
		RaycastHit2D hit = Physics2D.Raycast(PlayerMgr.instance.getPosition(), vec2 ,10,1<<10);
		Debug.Log (PlayerMgr.instance.getDirection ());
		if (hit.collider != null) {
			Debug.Log (hit.collider.name);
			Do (hit.collider);
			col = hit.collider;
		} 
	}

	private void Do(Collider2D collider) {
		switch (collider.tag) {
		case "MoveAble":
			collider.attachedRigidbody.constraints = RigidbodyConstraints2D.None;
			collider.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
			Drag.onDrag = true;
			isCancelable = true;
			break;
		case "UnMoveAble":
			//uiManager.ShowToast(true, "끌고 이동할 수 없는 물체다.");
			break;
		case "Trap":
			break;
		default:
			break;
		}
	}
}