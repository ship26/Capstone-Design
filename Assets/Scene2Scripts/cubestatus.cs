using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class cubestatus : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;
    public Transform start;
    NavMeshAgent agent;

    public RaycastHit hit;

   

    void Start()
    {

        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        start = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        




    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;


        if (Physics.Raycast(start.position, start.forward, out hit, 10))
        {
            if (hit.collider.CompareTag("bush"))
            {
                agent.isStopped = true;
            }
            if (hit.collider.CompareTag("ground"))
            {
                agent.isStopped = false;
            }

        }



    }


  

   

}
