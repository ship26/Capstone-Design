using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    public GameObject player;

    private PlayerInput playerinput;

    

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {

        CameraTurn();

        transform.Rotate(0, -90, 0);

      




    }


    private void CameraTurn()
    {

        if(player.transform.eulerAngles.y >=270 && player.transform.eulerAngles.y<=360)
        {
            transform.position = player.transform.position + new Vector3(-player.transform.eulerAngles.y / 400, 6.6f, -400 / player.transform.eulerAngles.y);  //modify this code (not correct )_
        }


    }


 
}
