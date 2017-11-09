using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject[] objetos;
    public bool spawnearObj;

	// Use this for initialization
	void Start ()
    {
        spawnearObj = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (spawnearObj)
        {
            spawnearObj = false;
            StartCoroutine(Esperar());
        }*/
    }

    private void Spawnear(int spwn)
    {
        //Instantiate(objetos[0], transform.position, new Quaternion());
        objetos[spwn].transform.position = transform.position;
        objetos[spwn].GetComponent<ObjetoLastima>().enabled = true;
    }

    public void Btn_Dolor()
    {
        //spawnearObj = true;
        if (spawnearObj)
        {
            spawnearObj = false;
            Spawnear(0);
        }
    }
    public void Btn_Agrado()
    {
        //spawnearObj = true;
        if (spawnearObj)
        {
            spawnearObj = false;
            Spawnear(1);
        }
    }
}
