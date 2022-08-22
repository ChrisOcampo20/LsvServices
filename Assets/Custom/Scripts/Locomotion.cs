using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
public class Locomotion : MonoBehaviour
{

    public Rigidbody player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var JoystickAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
        
        player.position += (transform.right * JoystickAxis.x + transform.forward * JoystickAxis.y) * Time.deltaTime * speed;
        player.position = new Vector3(player.position.x, player.position.y, player.position.z);

    }
}
