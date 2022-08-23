using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replacer : MonoBehaviour
{
    public GameObject emptyMesa;

    public BoxCollider maquetaCollider;

    public Collider pisoCollider;

    public Collider vacioCollider;

    private Quaternion savedRotation;
    // Start is called before the first frame update
    void Start()
    {
        maquetaCollider.GetComponentsInChildren<BoxCollider>();

        savedRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (maquetaCollider.bounds.Intersects(pisoCollider.bounds) || maquetaCollider.bounds.Intersects(vacioCollider.bounds))
        {
            transform.position = emptyMesa.transform.position + new Vector3(0, 0, 0);
            transform.rotation = savedRotation;
        }
        
        
    }
}
