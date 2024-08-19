using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask mask;
    public NavMeshAgent agent;
    public bool playerCanMove;

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
        //Physics.SphereCast();
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
}