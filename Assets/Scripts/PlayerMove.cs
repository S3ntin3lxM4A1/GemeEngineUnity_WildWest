using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask mask;
    public NavMeshAgent agent;
    public bool playerCanMove;

    [Range(0.1f, 7f)] public float attackRange;
    public LayerMask targetMask;

    public Camera kamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerCanMove)
        {
            MoveToClickPos();
        }
        KillRadius();
    }
    private void MoveToClickPos()
    {
        RaycastHit hit;
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if (isHit)
        {
            agent.destination = hit.point;
        }
    }
    public void KillRadius()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, attackRange, targetMask);
            foreach (var hitCollider in hit)
            {
                //what the Animal needs to do.
            }
    }
    public void MovePlayer()
    {
        playerCanMove = true;
    }
    public void MoveNoPLayer()
    {
        playerCanMove = false;
    }
    public void MoveStop()
    {
        agent.ResetPath();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}