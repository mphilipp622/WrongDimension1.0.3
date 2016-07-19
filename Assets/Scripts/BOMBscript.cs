using UnityEngine;
using System.Collections;

public class BOMBscript : MonoBehaviour {

    public GameObject smoke;
    public GameObject explosion;

    public bool thrownDown;
    public int throwSpeedLow;
    public int throwSpeedHigh;

    public int timerLow = 1;
    public int timerHigh = 2;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SmokeTimer());
        StartCoroutine(Timer());

        if (thrownDown)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, -(Random.RandomRange(throwSpeedLow,throwSpeedHigh)), 0, ForceMode.Impulse);
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -30, ForceMode.Impulse);

        }
        if (!thrownDown) { 
            gameObject.GetComponent<Rigidbody>().AddForce(0, (Random.RandomRange(throwSpeedLow, throwSpeedHigh)), 0, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -30, ForceMode.Impulse);
    }
    }
	
	// Update is called once per frame
	void Update () {
        }

    IEnumerator SmokeTimer()
    {
        
        yield return new WaitForSeconds(Random.Range(0.25f, 0.75f));
        Vector3 smoPOS = gameObject.GetComponent<Rigidbody>().position;
        smoPOS.y += Random.Range(0.5f, 2f);
        Instantiate(smoke, smoPOS, transform.rotation);
        StartCoroutine(SmokeTimer());
    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(Random.Range(timerLow, timerHigh));
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    }
