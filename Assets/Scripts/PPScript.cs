using UnityEngine;
using System.Collections;

public class PPScript : MonoBehaviour {

    public bool lit = false;

    public Sprite unLitSprite;
    public Sprite LitSprite;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (lit)
            gameObject.GetComponent<SpriteRenderer>().sprite = LitSprite;
        if (!lit)
            gameObject.GetComponent<SpriteRenderer>().sprite = unLitSprite;



    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "PDA")
        {
            Debug.Log("Triggered");
            if (lit) { lit = false; Debug.Log("UnLit"); }
            else if (!lit) { lit = true; Debug.Log("Lit"); }
        }

    }


}
