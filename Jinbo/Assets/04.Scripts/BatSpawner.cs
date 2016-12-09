using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour {

    [SerializeField]
    private float coolDown = 5.0f;
    [SerializeField]
    private float currentTime = 0.0f;

    public bool IsCoolDown
    {
        get
        {
            if (currentTime <= 0) return true;
            else return false;
        }
    }

    public GameObject batPrefab;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsCoolDown)
        {
            Instantiate(batPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            currentTime = coolDown;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
