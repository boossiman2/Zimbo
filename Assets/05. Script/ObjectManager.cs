using UnityEngine;
using System.Collections;

public class ObjectManager :MonoBehaviour {

	public string DO_SEARCH = "조사/행동";
	public string DO_OK = "확인";
	private bool isCancelable = false;

	//public Player player;
	public MoveableObjcet Drag;

	public void ClickDoButton() {
		if (isCancelable) {
			isCancelable = false;
			Drag.onDrag = false;
			return;
		}

		// Background 레이어를 제외한 것을 탐색.
		//RaycastHit2D hit = Physics2D.Raycast(player.getPosition(), player.getDirection(), 2, 9);
		if (hit.collider != null) {
			Do(hit.collider);
		}
	}

	private void Do(Collider2D collider) {
		switch (collider.tag) {
		case "moveable":
			//uiManager.setDoButtonText(DO_OK);
			Drag.onDrag = true;
			isCancelable = true;
			break;
		case "unmoveable":
			//uiManager.ShowToast(true, "끌고 이동할 수 없는 물체다.");
			//uiManager.setDoButtonText(DO_OK);
			isCancelable = true;
			break;
		default:
			break;
		}
	}
}