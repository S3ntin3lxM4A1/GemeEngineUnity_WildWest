using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeShow : MonoBehaviour
{
    public GameObject self;
    public float speed, time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        time -= Time.deltaTime;
        if (time <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
