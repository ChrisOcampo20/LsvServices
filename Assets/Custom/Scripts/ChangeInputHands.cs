using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInputHands : MonoBehaviour
{
    public GameObject trackeoDerecho;
    public GameObject trackeoIzquierdo;
    public GameObject controlDerecho;
    public GameObject controlIzquierdo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRPlugin.GetHandTrackingEnabled() == true)
        {
            trackeoDerecho.SetActive(true);
            trackeoIzquierdo.SetActive(true);
            controlDerecho.SetActive(false);
            controlIzquierdo.SetActive(false);

        }
        else if (OVRInput.GetActiveController()==OVRInput.Controller.Touch)
        {
            trackeoDerecho.SetActive(false);
            trackeoIzquierdo.SetActive(false);
            controlDerecho.SetActive(true);
            controlIzquierdo.SetActive(true);

        }
        else {
            trackeoDerecho.SetActive(false);
            trackeoIzquierdo.SetActive(false);
            controlDerecho.SetActive(false);
            controlIzquierdo.SetActive(false);


        }

    }
}
