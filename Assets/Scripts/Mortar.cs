using UnityEngine;
using System.Collections;

public class Mortar : MonoBehaviour {

    public GameObject cannonFire;
    public GameObject damageField;
    public GameObject deathExplosion;
    public int health;
    public float firingTimer;

    public GameObject bombDropper;
    //I didn't do a 'Find with tag' just in case we wanted more than one dropper in later levels


	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
	
        if (health <= 0)
        {
            Instantiate(deathExplosion, transform.position, transform.rotation);
            Destroy(bombDropper);
            Destroy(gameObject);
        }


	}




    void OnCollisionEnter(Collision col1)
    {
        if (col1.gameObject.tag == "Weapon")
        {
           
            health -= 10;

        }

    }


    IEnumerator Timer()
    {
        damageField.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(firingTimer);
        Vector3 smoPOS = gameObject.transform.position;
        smoPOS.z -= 6;
        smoPOS.y += 1.1f;
        Instantiate(cannonFire, smoPOS, transform.rotation);
        damageField.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(Timer());
    }

}
