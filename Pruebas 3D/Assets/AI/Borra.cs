using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borra : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {

        if (transform.position == new Vector3(-23.63f, 1.5f, -9.85f))
        {
            iTween.RotateTo(gameObject, new Vector3(0, 0, 0), 3f);
        }
        else if (transform.position == new Vector3(0, 1.5f, -4.3f))
        {
            iTween.RotateTo(gameObject, new Vector3(0, 180, 0), 3f);
        }
		
	}
}
