using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyController : MonoBehaviour
{
    [Header("- - - - - - Bunny Controller - - - - - -")]
    public LayerMask whatIsPlayer;
    public bool playerInSightRange;
    [Range(1,15)]public float sightRange;

    public NavMeshAgent agent;

    public int points;

    public UIController uiCont;
    public GameObject particle;
    private Quaternion qa;

    public float walkPointRange;
    public bool walkPointSet;
    public Vector3 walkPoint;
    public LayerMask whatIsGround;
    public GameObject player;
    public float fleeMultiplier = 1;
    public float fleeRange = 30;
    // Start is called before the first frame update
    void Start()
    {
        qa = new Quaternion(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
            Flee();
        if (!playerInSightRange)
            Patroling();
    }
    public void TakeAttack()
    {
        Instantiate(particle, transform.position, qa);
        uiCont.SetScore(points);
        Destroy(this.gameObject);
    }

    public void Patroling()
    {
        if (!walkPointSet) 
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    public void Flee()
    {
        Vector3 runTo = transform.position + ((transform.position - player.transform.position) * fleeMultiplier);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < fleeRange) agent.SetDestination(runTo);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, sightRange);
    }
}
