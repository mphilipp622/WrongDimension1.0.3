using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {



	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Random.RandomRange(-10, -15));
        //StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.z <= -600)
        {
            Destroy(gameObject);
        }


    }


    IEnumerator Timer()
    {

        yield return new WaitForSeconds(4);
        
    }
    }
