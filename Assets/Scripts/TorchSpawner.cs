using UnityEngine;
using System.Collections;

public class TorchSpawner : MonoBehaviour {

    public GameObject torchFlame;

	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Random.RandomRange(0.3f, 0.4f));
        Instantiate(torchFlame, gameObject.transform.position, transform.rotation);
        StartCoroutine(Timer());
    }
}
