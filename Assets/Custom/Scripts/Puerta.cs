using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{

    public GameObject player;
    public int playerDistance = 6;
    public int doorDistance = 3;
    private AudioSource sourceDoorOpen;
   
    private Vector3 savedPosition;
    private bool doorOpen;

    

    // Start is called before the first frame update
    void Start()
    {
        savedPosition = transform.position;
        doorOpen=false;
        
        sourceDoorOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position) <= playerDistance && doorOpen == false)
        {
            Debug.Log("Enter");
            transform.position += new Vector3(0, 0, doorDistance);
            sourceDoorOpen.Play(0);
            doorOpen = true;



        }
        
      if(Vector3.Distance(transform.position, player.transform.position) > playerDistance && doorOpen == true)
        {
            Debug.Log("Exit");
            transform.position = savedPosition;
            doorOpen = false;
        }


    }

   
}
