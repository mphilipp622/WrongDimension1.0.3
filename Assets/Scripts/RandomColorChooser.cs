using UnityEngine;
using System.Collections;

public class RandomColorChooser : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Random.Range(0.5f, 1f));

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
