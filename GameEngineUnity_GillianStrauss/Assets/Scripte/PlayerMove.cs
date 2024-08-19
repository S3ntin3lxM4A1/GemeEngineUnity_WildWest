using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask mask;
    public NavMeshAgent agent;

    public Camera kamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToClickPos();
        }
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
}