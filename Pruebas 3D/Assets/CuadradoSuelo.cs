using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadradoSuelo : MonoBehaviour {

    bool cubeActive;
    public Transform[] cubePosition;

	// Use this for initialization
	void Start ()
    {
        cubeActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direccion1 = Vector3.forward;
        Vector3 direccion2 = Vector3.back;
        Vector3 direccion3 = Vector3.left;
        Vector3 direccion4 = Vector3.right;
        RayDirection(direccion1);
        RayDirection(direccion2);
        RayDirection(direccion3);
        RayDirection(direccion4);
    }

    void RayDirection(Vector3 direccion)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direccion, out hit, 4))
        {
            if (direccion == Vector3.forward)
            {
                cubePosition[0] = hit.collider.GetComponent<Transform>();
            }
            if (direccion == Vector3.back)
            {
                cubePosition[1] = hit.collider.GetComponent<Transform>();
            }
            if (direccion == Vector3.left)
            {
                cubePosition[2] = hit.collider.GetComponent<Transform>();
            }
            if (direccion == Vector3.right)
            {
                cubePosition[3] = hit.collider.GetComponent<Transform>();
            }
        }

        Debug.DrawRay(transform.position, direccion * 4);
    }
}
