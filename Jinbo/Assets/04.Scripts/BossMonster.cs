using UnityEngine;
using System.Collections;


public class BossMonster : MonoBehaviour
{
    private float coolDown = 3.0f;
    private float currentTime = 3.0f;
    [SerializeField]
    private float speed = 1.5f;
    private float jumpSpeed = 10.0f;

    private bool isDash = false;
    private bool isJump = false;

    public float Speed
    {
        get { return speed; }
        private set { speed = value; }
    }

    public bool IsCoolDown
    {
        get
        {
            if (currentTime <= 0) return true;
            else return false;
        }
    }

    private IEnumerator SpeedDown(float time)
    {
        speed = speed * 0.8f;
        yield return new WaitForSeconds(time);
        speed = 1.5f; 
    }

    public void Slow(float time)
    {
        StartCoroutine(SpeedDown(time));
    }

    private string RandomMotion()
    {
        if(!IsCoolDown)
        {
            return " ";
        }
        int type = Random.Range(1, 3);
        Debug.Log(type);
        if(type == 1)
        {
            return "Jump";
        }
        else
        {
            return "Dash";
        }
    }

    private void WholeSkillDelay()
    {
        if(IsCoolDown)
        {
            StartCoroutine(WaitForSkills(RandomMotion()));
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private IEnumerator WaitForSkills(string name)
    {
        if (name == "Dash" && isJump == false)
        {
            Debug.Log("Dash");
            speed = 9;
            isDash = true;
            yield return new WaitForSeconds(0.3f);
            speed = 1.5f;
            isDash = false;
        }
        if ((name == "Jump" && isDash == false)|| isJump )
        {
            Debug.Log("Jump");
            isJump = true;
            transform.Translate(new Vector3(0, jumpSpeed * Time.deltaTime, 0));
            yield return new WaitForSeconds(2.0f);
            isJump = false;
        }
        currentTime = coolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        WholeSkillDelay();
        if(Input.GetKey(KeyCode.A))
        {
            Slow(1.0f);
        }
    } 

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Equals ("Player")) { // 플레이어와 충돌한 경우
			if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.immortal) { // 플레이어 현재 상태가 무적이면
				Debug.Log ("영웅은 죽지 않아요.");
			} else if (PlayerMgr.instance._spec == PlayerMgr.playerSpec.normal) { // 플레이어 현재 상태가 정상이면
				PlayerMgr.instance._state = PlayerMgr.playerState.dead;
			}
		} 
		else if (col.name.Equals ("Sword")) {
		}
	}
}
