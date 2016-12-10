using UnityEngine;
using System.Collections;

[System.Serializable]
public class GizmosInfo{
	public Color targetColor = Color.magenta;
	public float targetRadius = 0.2f;
	public Color cameraColor = Color.blue;
	public float cameraRadius = 0.5f;
	public Color lineColor = Color.red;
}
public class FollowCam : MonoBehaviour {
	public Transform targetTr;
	private Transform cameraTr;

	public GizmosInfo gizmosInfo;	
	// Use this for initialization
	public float marginX = 1.0f;
	public float marginY = 1.0f;
	public float dampingX = 1.0f;
	public float dampingY = 1.0f;


	void OnDrawGizmos(){
		Gizmos.color = gizmosInfo.targetColor;
		Gizmos.DrawWireSphere (targetTr.position, gizmosInfo.targetRadius);

		Gizmos.color = gizmosInfo.cameraColor;
		Gizmos.DrawWireSphere (transform.position, gizmosInfo.cameraRadius);

		Gizmos.color = gizmosInfo.lineColor;
		Gizmos.DrawLine(transform.position, targetTr.position);

	}
	void Start () {
		cameraTr = GetComponent<Transform> ();

	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float moveX = cameraTr.position.x;
		float moveY = cameraTr.position.y;

		if (CheckMarginX ()) {
			moveX = Mathf.Lerp (cameraTr.position.x, targetTr.position.x, Time.deltaTime * dampingX);
		}
		if (CheckMarginY ()) {
			moveY = Mathf.Lerp (cameraTr.position.y, targetTr.position.y, Time.deltaTime * dampingY);
		}
		cameraTr.position = new Vector3 (moveX, moveY, cameraTr.position.z);
	}

	bool CheckMarginX(){
		return(Mathf.Abs (cameraTr.position.x - targetTr.position.x) > marginX);
	}
	bool CheckMarginY(){
		return(Mathf.Abs (cameraTr.position.y - targetTr.position.y) > marginY);
	}
}
