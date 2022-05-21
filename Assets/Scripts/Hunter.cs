using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Hunter : MonoBehaviour
{

    public GameObject gun;  // 사용할 총
    public Transform gunPivot;  //총 배치의 기준점
    public Transform leftHandMount;

    public LayerMask whatisTarget;  //추적 대상 레이어
    public GameObject targetEntity; //추적 대상
    private NavMeshAgent pathFinder; //경로 계산및 추적 실행

    private Animator hunterAnimator;  //애니메이터 컴포넌트
    AudioSource audiosource;
    public AudioClip laugh;
    public AudioClip pistol;



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
        hunterAnimator = GetComponent<Animator>();
        pathFinder = GetComponent<NavMeshAgent>();
        audiosource = GetComponent<AudioSource>();
        dead = false;
        pathFinder.speed = 0.8f;
        hunterAnimator.SetBool("isRun", true);
       
        
        StartCoroutine(UpdatePath());
        StartCoroutine(Laugh1());
        StartCoroutine(Laugh2());
        StartCoroutine(Laugh3());
        StartCoroutine(Shot1());
        StartCoroutine(Shot2());
        StartCoroutine(Dead1());
    }

    // Update is called once per frame
    void Update()
    {
      





    }



    private void OnAnimatorIK(int layerIndex)
    {
        //walk and run

        gunPivot.position = hunterAnimator.GetIKHintPosition(AvatarIKHint.LeftElbow);
        gunPivot.position = gunPivot.position + new Vector3(-0.12f, -0.25f, -0.08f);


    }

    IEnumerator Laugh1()
    {


        yield return new WaitForSeconds(3.0f);

        audiosource.clip = laugh;
        audiosource.Play();

    }

    IEnumerator Laugh2()
    {


        yield return new WaitForSeconds(9.0f);

        audiosource.clip = laugh;
        audiosource.Play();

    }

    IEnumerator Laugh3()
    {


        yield return new WaitForSeconds(15.0f);

        audiosource.clip = laugh;
        audiosource.Play();

    }

    IEnumerator Shot1()
    {


        yield return new WaitForSeconds(5.0f);

        audiosource.clip = pistol;
        audiosource.Play();

    }

    IEnumerator Shot2()
    {


        yield return new WaitForSeconds(15.0f);

        audiosource.clip = pistol;
        audiosource.Play();

    }

    IEnumerator Dead1()
    {


        yield return new WaitForSeconds(25.0f);

        Destroy(gameObject);


    }

  




    private IEnumerator UpdatePath()
    {


        while (!dead)
        {

            if (hasTarget)
            {
                hunterAnimator.SetBool("isRun", true);
                pathFinder.isStopped = false;
                pathFinder.SetDestination(targetEntity.transform.position);
                



            }
            else
            {
                
                pathFinder.isStopped = true;
                hunterAnimator.SetBool("isRun", false);

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

    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.CompareTag("bush"))    //만약 객체가 특정 지역 안에 있을 경우
        {


            targetEntity = null;
            


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
