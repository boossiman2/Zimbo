using UnityEngine;
using System.Collections;


public class BossMonster : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    private float coolDown = 5f;
    private float currentTime = 4f;

	[SerializeField]
    private float speed = 2f;
    private float jumpSpeed = 10.0f;

    private bool isDash = false;
    private bool isJump = false;

    private float spawnDelay = 5.0f;

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
        speed = 1.6f;
        yield return new WaitForSeconds(time);
        speed = 2f; 
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

    private void SpawnDelay()
    {
         if(currentTime<=0)
        {
            return;
        }
        else
        {
            spawnDelay -= Time.deltaTime;
        }
    }

    void Awake()
    {
        
        currentTime = spawnDelay;
    }

    void Start()
    {

    }

    private IEnumerator WaitForSkills(string name)
    {
        if (name == "Dash" && isJump == false)
        {
            Debug.Log("Dash");
            speed = 3.75f;
            isDash = true;
            animator.SetBool("isDash", true);
            yield return new WaitForSeconds(2f);
            speed = 2f;
            animator.SetBool("isDash", false);
            isDash = false;
        }
        if ((name == "Jump" && isDash == false)|| isJump )
        {
            Debug.Log("Jump");
            isJump = true;
            animator.SetBool("isJump", true);
            transform.Translate(new Vector3(0, jumpSpeed * Time.deltaTime, 0));
            yield return new WaitForSeconds(2.0f);
            animator.SetBool("isJump",false);
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
}
