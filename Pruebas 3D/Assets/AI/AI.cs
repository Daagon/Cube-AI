using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float distancia;
    private Rigidbody rb;
    private bool enfrenteObj;
    public GameObject myOtherself;
    public int contD = 0;
    public int contG = 0;
    public List<GameObject> objetos = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        enfrenteObj = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vista();
        Debug.DrawRay(transform.position, Vector3.down * 0.53f);
    }

    void RespuestaAsociada()
    {
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.51f))
            rb.AddForce(transform.up * distancia);

        if (enfrenteObj)
        {
            if(distancia < 400)
            distancia += 50;
        }
    }

    void Vista()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
        {
            Vector3 posicionObj = hit.transform.position - transform.position;

            Debug.Log("Puedo ver un objeto");

            if (contD >= 4 && contD > contG && /*objetos[0].tag == "Dolor" &&*/ posicionObj.x < 2f && hit.collider.GetComponent<ObjetoLastima>().movimiento)
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.51f))
                {
                    RespuestaAsociada();
                }
                
                /*foreach (GameObject objeto in objetos)
                {
                    if (objeto.tag == "Dolor" && posicionObj.x < 2f && hit.collider.GetComponent<ObjetoLastima>().movimiento)
                        RespuestaAsociada();
                }*/
            }
            else if (contG >= 4 && contG > contD /*&& objetos[0].tag == "Nada"*/ && posicionObj.x < 2.5f)
            {
                StartCoroutine(Gusto());
            }

            if (posicionObj.x < 1.4f)
            {
                Debug.Log("El objeto está muy cerca");
                enfrenteObj = true;
            }
            else
                enfrenteObj = false;

        }

        Debug.DrawRay(transform.position, Vector3.right * 10, Color.red);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Suelo")
        {
            if (objetos.Count == 0)
                objetos.Add(col.gameObject);
            for (int i = 0; i < objetos.Count; i++) //TAL VEZ HAYAN MEJORES FORMAS DE HACER ESTO...
            {
                if (objetos[i].tag == col.gameObject.tag)
                {
                    break;
                }
                if (i == objetos.Count - 1)
                {
                    objetos.Add(col.gameObject);
                }
            }
        }

        if (col.gameObject.tag == "Dolor")
        {
            RespuestaAsociada();
        }
        if (col.gameObject.tag == "Nada")
        {
            StartCoroutine(Gusto());
        }
        if (col.gameObject.name != "Suelo")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 120);
        }
    }

    IEnumerator Gusto()
    {
        Vector3 posTemp = transform.position;
        Debug.Log("GIRAR");
        transform.position = new Vector3(-23.63f, 1.5f, -9.85f);
        myOtherself.transform.position = posTemp;
        yield return new WaitForSeconds(3f);
        myOtherself.transform.position = new Vector3(-23.63f, 1.5f, -9.85f);
        transform.position = posTemp;
    }
}
