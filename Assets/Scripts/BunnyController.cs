using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    private bool playerInSighRange;
    public float sightRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSighRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSighRange)
            Flee();
        if (!playerInSighRange)
            Patroling();
    }

    public void Patroling()
    {

    }
    public void Flee()
    {

    }
}
