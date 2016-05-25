using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public int flyupSpeedLow;
    public int flyupSpeedhigh;

    public GameObject explosion;


    // Use this for initialization
    void Start () {
       
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Random.RandomRange(-flyupSpeedLow, -flyupSpeedhigh));

        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col1)
    {
        Instantiate(explosion, gameObject.transform.position, transform.rotation);
        Destroy(gameObject);
        

    }

    IEnumerator Timer()
    {
        //Just in case theres an issue and it doesnt collide with anything. 
        yield return new WaitForSeconds(30);
        Destroy(gameObject);

    }
}
