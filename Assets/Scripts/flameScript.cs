using UnityEngine;
using System.Collections;

public class flameScript : MonoBehaviour {

    Vector3 startingScale;
    Rigidbody myRig;
    Vector3 v;



    // Use this for initialization
    void Start () {
        startingScale = gameObject.transform.localScale;
        startingScale.y = Random.RandomRange(0.5f, 0.8f);
        gameObject.transform.localScale = new Vector3(startingScale.x, startingScale.y, startingScale.z);
        //Physics.gravity = new Vector3(0, 0, -5f);
        startingScale.y = 0;
        StartCoroutine(Timer());
        myRig = gameObject.GetComponent<Rigidbody>();
        v = myRig.velocity;
        v.y += Random.RandomRange(-0.3f, 0.75f);
        v.z += Random.RandomRange(-5f, -3f);
        myRig.velocity = new Vector3(v.x, v.y, v.z);
    }
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, startingScale, 2f * Time.deltaTime);

        
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
