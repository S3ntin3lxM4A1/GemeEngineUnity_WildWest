using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject anker1, anker2, player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPlayer1()
    {
        player.transform.position = anker1.transform.position;
    }
    public void SpawnPlayer2() 
    {
        player.transform.position = anker2.transform.position;
    }
}
