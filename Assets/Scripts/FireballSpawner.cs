using UnityEngine;
using System.Collections;

public class FireballSpawner : MonoBehaviour {

    public GameObject fireBall;
    public float spawnTime;
    public AudioClip fireballHiss;
    AudioSource FBSource;
    public int flyupSpeedLow1;
    public int flyupSpeedhigh1;


    // Use this for initialization
    void Start () {
        StartCoroutine(Timer());
        FBSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(spawnTime);
        
        FBSource.clip = fireballHiss;
        FBSource.Play();
         GameObject spawnedFireball =   (GameObject)Instantiate(fireBall, gameObject.transform.position, transform.rotation);
        spawnedFireball.GetComponent<Fireball>().flyupSpeedLow = flyupSpeedLow1;
        spawnedFireball.GetComponent<Fireball>().flyupSpeedhigh = flyupSpeedhigh1;
        StartCoroutine(Timer());
    }
}
