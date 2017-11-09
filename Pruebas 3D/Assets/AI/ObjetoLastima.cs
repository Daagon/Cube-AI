using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLastima : MonoBehaviour {

    public bool movimiento;
    public float speed;
    //public GameObject cubo;

	// Use this for initialization
	void Start ()
    {
        movimiento = false;
        //est = Estado.ESPERAR;
        //cubo = GameObject.FindGameObjectWithTag("Conduc");
        StartCoroutine(Esperar3());
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(Esperar2());
            GetComponent<Rigidbody>().AddForce(-5,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody>().AddForce(5, 0, 0);
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            StartCoroutine(Esperar());
        }*/
        
        if (movimiento)
        {
            GetComponent<Rigidbody>().AddForce(-speed * Time.deltaTime, 0, 0);
        }
        /*else
        {
            if (est == Estado.ADELANTE)
            {
                est = Estado.ESPERAR;
                StartCoroutine(Esperar());
            }
        }*/
    }

    /*IEnumerator Esperar2()
    {
        yield return new WaitForSeconds(0.5f);
        movimiento = true;
    }*/
    IEnumerator Esperar3()
    {
        yield return new WaitForSeconds(1f);
        movimiento = true;
        //est = Estado.ADELANTE;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Fin")
        {
            GameObject.FindGameObjectWithTag("Spawner").GetComponent<Spawn>().spawnearObj = true;
            if(gameObject.tag == "Dolor")
                GameObject.FindGameObjectWithTag("Conduc").GetComponent<AI>().contD++;
            else if (gameObject.tag == "Nada")
                GameObject.FindGameObjectWithTag("Conduc").GetComponent<AI>().contG++;
            GetComponent<ObjetoLastima>().enabled = false;
        }
    }
}
