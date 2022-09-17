using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;

public class HandGrabber : OVRGrabber
{
    public OVRHand hand;
    public float pinchTreshold = 0.7f;

    public Text handDetails;

    public Text IndexText;
    public Text RingText;
    public Text MiddleText;
    public Text PinkyText;
    public Text MaxText;
    public Text ThumbText;

    private Rigidbody rb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //hand =  hand.GetComponent<OVRHand>();
        if (m_grabbedObj)
        {
            rb = m_grabbedObj.GetComponent<Rigidbody>();
        }

    }

    public override void Update()
    {
        base.Update();

        CheckIndexPinch();

    }

    public void CheckIndexPinch()
    {
        float pinchIndexStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Index);



        float pinchRingStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Ring);

        float pinchPinkyStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Pinky);


        IndexText.text = pinchIndexStrength.ToString();
        RingText.text = pinchRingStrength.ToString();
        //MiddleText.text = pinchMiddleStrength.ToString();
        PinkyText.text = pinchPinkyStrength.ToString();


        bool isPinching = pinchIndexStrength > pinchTreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
            GrabBegin();
        else if (m_grabbedObj && !isPinching)
            GrabEnd();

        float pinchMaxStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Max);
        MaxText.text = pinchMaxStrength.ToString();
        float pinchThumbStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Thumb);
        ThumbText.text = pinchThumbStrength.ToString();

    }

    protected override void GrabBegin()
    {
        base.GrabBegin();
        handDetails.text = transform.name;

        if (rb != null && rb.isKinematic == false)
        {
            rb.isKinematic = true;
        }
    }

    public override void GrabEnd()
    {
        if (m_grabbedObj)
        {
            Vector3 lineraVelocity = (transform.position - m_lastPos) / Time.fixedDeltaTime;
            Vector3 angularVelocity = (transform.eulerAngles - m_lastRot.eulerAngles) / Time.fixedDeltaTime;

            GrabbableRelease(lineraVelocity, angularVelocity);

        }
        if (rb != null && rb.isKinematic == true)
        {
            rb.isKinematic = false;
        }

        GrabVolumeEnable(true);
    }


}