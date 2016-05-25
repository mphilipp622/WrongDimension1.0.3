using UnityEngine;
using System.Collections;

public class TimedDeathSimple : MonoBehaviour {

    public float deathTime = 5;
    public bool disableCollider = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
        if (disableCollider)
            StartCoroutine(Timer2());


        
    }

    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Collider>().enabled = false;
    }

        IEnumerator Timer()
    {

        yield return new WaitForSeconds(deathTime);

        Destroy(gameObject);
    }
}
