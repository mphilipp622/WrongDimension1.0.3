using UnityEngine;
using System.Collections;

public class NewPPDetect : MonoBehaviour {

    public bool lit = false;
    bool canChange;

    public Sprite unLitSprite;
    public Sprite LitSprite;

    public AudioClip lockingSound;
    public AudioClip unlockingSound;
    public AudioSource Aud;

    // Use this for initialization
    void Start()
    {
        Aud = gameObject.GetComponent<AudioSource>();
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (lit)
            gameObject.GetComponent<SpriteRenderer>().sprite = LitSprite;
        if (!lit)
            gameObject.GetComponent<SpriteRenderer>().sprite = unLitSprite;



    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("First Triggered");
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PDA" /* || col.gameObject.tag == "Weapon"*/)
        {
            if (canChange)
            {
                Debug.Log("Triggered");
                if (lit)
                {
                    lit = false; Debug.Log("UnLit");
                    Aud.PlayOneShot(lockingSound, 1);
                    canChange = false;
                }
                else if (!lit)
                {
                    lit = true;
                    Aud.PlayOneShot(unlockingSound, 1);
                    Debug.Log("Lit");
                    canChange = false;
                }
            }
        }

    }

    void OnTriggerExit(Collider col)
    {
        canChange = true;
    }


    }
