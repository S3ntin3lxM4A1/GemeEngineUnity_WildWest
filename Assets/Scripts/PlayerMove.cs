using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask mask;
    public NavMeshAgent agent;
    public bool playerCanMove;
    public bool playerCanKill;

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
        if (playerCanKill)
        {
            Collider[] hit = Physics.OverlapSphere(transform.position, attackRange, targetMask);
            foreach (var hitCollider in hit)
            {
                if (hitCollider.CompareTag("Bunny"))
                {
                    var bc = hitCollider.gameObject.GetComponent<BunnyController>();
                    bc.TakeAttack();
                }
                if (hitCollider.CompareTag("Deer"))
                {
                    var dc = hitCollider.gameObject.GetComponent<DeerController>();
                    dc.TakeAttack();
                }
            }
        }
    }
    public void MovePlayer()
    {
        playerCanKill = true;
        playerCanMove = true;
    }
    public void MoveNoPLayer()
    {
        playerCanKill = false;
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