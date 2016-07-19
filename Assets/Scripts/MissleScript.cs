using UnityEngine;
using System.Collections;

public class MissleScript : MonoBehaviour {


    Rigidbody myRig;
    Vector3 v;
    public float missileSpeed;
    public GameObject explosion;
    public GameObject missileSmoke;

    public int shootingUp;
    // Use this for initialization
    
    void Start () {

        Debug.Log(shootingUp);
        myRig = gameObject.GetComponent<Rigidbody>();
        v = myRig.velocity;

        if (shootingUp == 1)
        {
            v.y += missileSpeed;
            myRig.velocity = new Vector3(v.x, v.y, v.z);
        }

        if (shootingUp != 1)
        {
            v.y -= missileSpeed;
            myRig.velocity = new Vector3(v.x, v.y, v.z);
        }

        StartCoroutine(SmokeTimer());
        StartCoroutine(DestroyTimer());


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col1)
    {
         if (col1.gameObject.tag == "PDA" || col1.gameObject.tag == "Weapon")
         {
            Vector3 smoPOS2 = gameObject.transform.position;
            smoPOS2.y += Random.Range(-2f, 2f); ;
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            Instantiate(explosion, gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
         }

    }

    IEnumerator SmokeTimer()
    {
        yield return new WaitForSeconds(Random.Range(0.01f, 0.08f));
        Vector3 smoPOS = gameObject.transform.position;
        Instantiate(missileSmoke, smoPOS, transform.rotation);
        StartCoroutine(SmokeTimer());
    }


    IEnumerator DestroyTimer()
    {
        //Just in case theres an issue and it doesnt collide with anything. 
        yield return new WaitForSeconds(40);
        Destroy(gameObject);

    }


}
