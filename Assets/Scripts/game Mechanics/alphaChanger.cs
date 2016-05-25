using UnityEngine;
using System.Collections;

public class alphaChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "AlphaChanger")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.4f);
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "AlphaChanger")
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }

    }
}
