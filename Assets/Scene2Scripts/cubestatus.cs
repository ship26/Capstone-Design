using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class cubestatus : MonoBehaviour
{
    // Start is called before the first frame update


   // public Transform target;
  //  public Transform start;
  //  NavMeshAgent agent;

   // public RaycastHit hit;
    public LayerMask whatisTarget;  //추적 대상 레이어
    public GameObject targetEntity; //추적 대상
    private NavMeshAgent pathFinder; //경로 계산및 추적 실행
    
    private bool dead;

    private bool hasTarget
    {
        get
        {

            if (targetEntity != null)
            {
                return true;
            }

            return false;
        }

    }



    void Start()
    {

       // target = GameObject.FindWithTag("Player").GetComponent<Transform>();
       // start = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
       // agent = GetComponent<NavMeshAgent>();
        pathFinder = GetComponent<NavMeshAgent>();
        dead = false;

        pathFinder.speed = 5;

        StartCoroutine(UpdatePath());


    }

    // Update is called once per frame


/*    void Update()
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


  */



    private IEnumerator UpdatePath()
    {


        while (!dead)
        {

            if(hasTarget)
            {


                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);


            }
            else
            {
                
                pathFinder.isStopped = true;

                Collider[] coliders =
                    Physics.OverlapSphere(transform.position, 20f,whatisTarget);

                //Debug.Log(transform.position);
                Debug.Log(coliders.Length);
                for ( int i=0; i<coliders.Length;i++)
                {

                    spherecontrol sc = coliders[i].GetComponent<spherecontrol>();
                    
                    
                    
                    if (sc.isbush == true)
                    {
                        targetEntity = null;
                        break;
                    }
                    else if(sc.isbush == false)
                    {
                        targetEntity = sc.gameObject;
                        break;

                    }


                }



            }
            
            
            yield return new WaitForSeconds(0.25f);


        }




    }



    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.CompareTag("bush"))    //만약 객체가 특정 지역 안에 있을 경우
        {


            targetEntity = null;



        }


    }
















}




