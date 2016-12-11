using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneAnimatin : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer renderer;
    private float runCooltime = 2.5f;
    private float idleCooltime = 1.5f;

    private int direction = 1;
    public void move()
    {
        if(runCooltime > 0)
        {
            animator.SetInteger("playerState", 1);
            transform.Translate(new Vector3(2 * Time.deltaTime * direction, 0, 0));
            runCooltime -= Time.deltaTime;
        }  
        else if(runCooltime <=0 && idleCooltime > 0)
        {
            animator.SetInteger("playerState", 0);
            idleCooltime -= Time.deltaTime;  
        }
        else if(runCooltime<=0 && idleCooltime <=0)
        {
            idleCooltime = 1.0f;
            runCooltime = 2.0f;
            direction = direction * -1;
            if(renderer.flipX)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
            
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}
}
