using UnityEngine;
using System.Collections;

public class SpiderSpawner : MonoBehaviour
{

    public GameObject spiderPrefab;

    // Use this for initialization
    void Start()
    {
		Instantiate(spiderPrefab, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
    }

    // Update is called once per frame



}
