using UnityEngine;
using System.Collections;

public class LBLCharge : MonoBehaviour {

    Animator animator;
    public AudioSource backgroundNoise;
    public AudioSource firingSource;
    public GameObject MagicMissile;

    public bool shootingUp;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(Timer());


    }
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator Timer()
    {
        //firingSource.Play();
        animator.SetBool("Firing", true);
        yield return new WaitForSeconds(4.63f);
        animator.SetBool("Firing", false);
        GameObject instObject = Instantiate(MagicMissile, gameObject.transform.position, transform.rotation) as GameObject;
        
        //Instantiate(MagicMissile, gameObject.transform.position, transform.rotation);

        if (shootingUp)
            instObject.GetComponent<MissleScript>().shootingUp = 1;

        yield return new WaitForSeconds(7);

        StartCoroutine(Timer());
    }
}
