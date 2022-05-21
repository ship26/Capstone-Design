using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadmonkey : MonoBehaviour
{
    private float time;

    private Animator animator;
   
    private bool isdead = false;
    AudioSource audiosource;
    public AudioClip a;
    // Start is called before the first frame update
    void Start()
    {
        
        audiosource = GetComponent<AudioSource>();
        
        animator = GetComponent<Animator>();
        
        audiosource.playOnAwake = false;
        audiosource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
       // Debug.Log(time);
        if (time > 1)    
        {
            animator.SetBool("isdead", true);


            if (!audiosource.isPlaying && isdead == false)
            {
                audiosource.Play();
                isdead = true;
            }

            


        }


    }


 


}
