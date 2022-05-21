using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Exterminator : MonoBehaviour
{



    public LayerMask whatisTarget;  //추적 대상 레이어
    public GameObject targetEntity; //추적 대상
    private NavMeshAgent pathFinder; //경로 계산및 추적 실행
    private Animator hunterAnimator;  //애니메이터 컴포넌트


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


    // Start is called before the first frame update
    void Start()
    {


        targetEntity = GameObject.Find("Ham2");
        pathFinder = GetComponent<NavMeshAgent>();
        pathFinder.speed = 3.8f;
        dead = false;
        StartCoroutine(UpdatePath());
        StartCoroutine(Excute());
        
    }

    // Update is called once per frame
    void Update()
    {




    }

    
    IEnumerator Excute()
    {


        yield return new WaitForSeconds(300.0f);

        gameObject.SetActive(true);


    }






    private IEnumerator UpdatePath()
    {


        while (!dead)
        {

            if (hasTarget)
            {

                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);




            }
            else
            {

                pathFinder.isStopped = true;

                Collider[] coliders =
                    Physics.OverlapSphere(transform.position, 20f, whatisTarget);

                //Debug.Log(transform.position);
                // Debug.Log(coliders.Length);
                for (int i = 0; i < coliders.Length; i++)
                {

                    Player_Ctrl_Ham sc = coliders[i].GetComponent<Player_Ctrl_Ham>();



                    if (sc.isbush == true)
                    {
                        targetEntity = null;
                        break;
                    }
                    else if (sc.isbush == false)
                    {
                        targetEntity = sc.gameObject;
                        break;

                    }


                }



            }


            yield return new WaitForSeconds(0.25f);


        }


    }






    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Player")
        {


            Destroy(col.gameObject);


        }


    }



}
