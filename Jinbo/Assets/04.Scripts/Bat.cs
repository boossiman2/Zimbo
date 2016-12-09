using UnityEngine;
using System.Collections;
public class Bat : MonoBehaviour
{
    public float speed = 18.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Destroy(this, 25.0f);
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
