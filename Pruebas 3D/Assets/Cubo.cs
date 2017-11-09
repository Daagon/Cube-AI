using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour {

    public bool abierto;

    public GameObject door;

	// Use this for initialization
	void Start () {
        abierto = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S) && !abierto)
        {
            abierto = true;
            iTween.RotateTo(door, new Vector3(0, -120, 0), 3.0f);
        }
        else if (Input.GetKeyDown(KeyCode.S) && abierto)
        {
            abierto = false;
            iTween.RotateTo(door, new Vector3(0, 0, 0), 3.0f);
        }

        if (Input.GetKeyDown(KeyCode.Q) && name == "puerta")
            Debug.Log("HOLA");
    }

    public void AbrirPuerta()
    {
        iTween.RotateTo(door, new Vector3(0, -120, 0), 3.0f);
    }
}
