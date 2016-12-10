using UnityEngine;
using System.Collections;

public class RayCastManager :MonoBehaviour {

	public string DO_SEARCH = "조사/행동";
	public string DO_OK = "확인";
	private bool isCancelable = false;

	public PlayerSub playerSub;
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

		// Background 레이어를 제외한 것을 탐색.
		RaycastHit2D hit = Physics2D.Raycast(playerSub.getPosition(), playerSub.getDirection(),1,1<<10);
		if (hit.collider != null) {
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
			PlayerSub.state = "Die";
			break;
		default:
			break;
		}
	}
}