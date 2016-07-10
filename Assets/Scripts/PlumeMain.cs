using UnityEngine;
using System.Collections;

public class PlumeMain : MonoBehaviour {

    public GameObject PlumeSmoke;



    // Use this for initialization
    void Start()
    {
        StartCoroutine(SmokeTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SmokeTimer()
    {

        yield return new WaitForSeconds(Random.Range(0.75f, 2f));
        Vector3 smoPOS = gameObject.transform.position;
        smoPOS.y += Random.Range(-2f, 2f);
        Instantiate(PlumeSmoke, smoPOS, transform.rotation);
        StartCoroutine(SmokeTimer());
    }
}