using UnityEngine;
using System.Collections;

public class SpawnerManagement : MonoBehaviour
{

	public GameObject spawnerPrefab;
	public int count;
	public string name;

	void Awake()
	{
		Debug.Log ("Init");
	}

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Init");
		SetObjectInMap (name);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetObjectInMap(string name)
	{
		
		for (int i = 0; i < count; i++) {
			if (name == "Spider") {
				Instantiate (spawnerPrefab, new Vector3 (this.transform.position.x + (i * 20), this.transform.position.y, 0), Quaternion.identity);
			} 
			else if (name == "Bat") {
			}
			Instantiate (spawnerPrefab, new Vector3 (this.transform.position.x + (i * 20), 0.7f, 0), Quaternion.identity);
		}
	}

}

