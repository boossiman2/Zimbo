using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneAnimatin : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    private float runDelay = 4.0f;
    private float idleDelay = 1.0f;
    private float currentTime = 0.0f;
    public void move()
    {
        currentTime = runDelay;
        transform.Translate(new Vector3(2 * Time.deltaTime, 0, 0));

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
