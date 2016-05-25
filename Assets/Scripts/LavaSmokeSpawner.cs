using UnityEngine;
using System.Collections;

public class LavaSmokeSpawner : MonoBehaviour {

    public GameObject smoke;



	// Use this for initialization
	void Start () {
        StartCoroutine(SmokeTimer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator SmokeTimer()
    {

        yield return new WaitForSeconds(Random.Range(0.1f, 4f));
        Vector3 smoPOS = gameObject.transform.position;
        smoPOS.y += Random.Range(-5f, 5f);
        Instantiate(smoke, smoPOS, transform.rotation);
        StartCoroutine(SmokeTimer());
    }
}
