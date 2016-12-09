using UnityEngine;
using System.Collections;

public class SpiderSpawner : MonoBehaviour
{
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

    public GameObject spiderPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(IsCoolDown)
        {
            Instantiate(spiderPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            currentTime = coolDown;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
