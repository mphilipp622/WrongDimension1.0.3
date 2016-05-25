using UnityEngine;
using System.Collections;

public class BloodSlpatterBehavior : MonoBehaviour {

    Rigidbody rigidBody;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        transform.localScale += new Vector3(0, Random.Range(-0.02f, 0.06f), 0);
        //Blood Up force
        rigidBody.AddForce(Vector3.forward * -Random.Range(2000f, 2500f));
        //Blood Forward force
        rigidBody.AddForce(Vector3.up * -Random.Range(-700f, 700f));
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = rigidBody.position;

        pos.x = 0;

        transform.position = new Vector3(pos.x, pos.y, pos.z);

    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(Random.Range(2, 5));
        
        Destroy(gameObject);
    }
}
