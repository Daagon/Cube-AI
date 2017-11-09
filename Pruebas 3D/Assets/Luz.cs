using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour {

    public KeyCode tecla1, tecla2;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        EstadoLuz();
    }

    void EstadoLuz()
    {
        if (Input.GetKey(tecla1)) transform.Rotate(0.4f,0,0);
        if (Input.GetKey(tecla2)) transform.Rotate(-0.4f, 0, 0);
    }
}
