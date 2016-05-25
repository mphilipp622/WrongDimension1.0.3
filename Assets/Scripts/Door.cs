using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool keyA;
    public bool keyA1 = false;
    public GameObject keyAGO;
    public bool keyB;
    public bool keyB1 = false;
    public GameObject keyBGO;
    public bool keyC;
    public bool keyC1 = false;
    public GameObject keyCGO;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    bool locked;

    public AudioClip doorLocking;
    public AudioClip doorUnlocking;





	// Use this for initialization
	void Start () {
        locked = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(keyA1 == keyA && keyB1 == keyB && keyC1 == keyC)
        {
            Debug.Log("DOOR UNLOCKED");
            gameObject.GetComponent<SpriteRenderer>().sprite = unlockedSprite;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<AudioSource>().clip = doorLocking;
            //gameObject.GetComponent<AudioSource>().Play();
        }
        if (keyA1 != keyA || keyB1 != keyB || keyC1 != keyC)
        {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = lockedSprite;
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.GetComponent<AudioSource>().clip = doorUnlocking;
            //gameObject.GetComponent<AudioSource>().Play();

        }

        keyA1 = keyAGO.GetComponent<NewPPDetect>().lit;
        keyB1 = keyBGO.GetComponent<NewPPDetect>().lit;
        keyC1 = keyCGO.GetComponent<NewPPDetect>().lit;

    }

    



}
