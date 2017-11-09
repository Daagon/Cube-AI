using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

    public float speed;
    public GameObject cabeza;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-speed,0,0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0, 0, speed);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0, 0, -speed);

        RaycastHit hit;
        if (Physics.Raycast(cabeza.transform.position, transform.forward, out hit, 1.5f))
        {
            if (hit.collider.name == "puerta")
            {
                Debug.DrawLine(cabeza.transform.position, hit.point);
                Debug.Log("PUERTA");
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<Cubo>().AbrirPuerta();
                    hit.collider.GetComponent<Cubo>().abierto = true;
                }
            }
        }
    }
}
