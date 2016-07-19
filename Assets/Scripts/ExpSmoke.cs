using UnityEngine;
using System.Collections;

public class ExpSmoke : MonoBehaviour {
    
    public Sprite redSprite;
    public Sprite yellowSprite;
    public Sprite orangeSprite;
    public Sprite greySprite;
    int index;

    bool thrownDown;
    public int throwSpeedLow;
    public int throwSpeedHigh;

    public bool isSpark;

    float uporDown;

    // Use this for initialization
    void Start () {
        uporDown = Random.RandomRange(0,2);

        if (uporDown >= 1.1f)
            thrownDown = false;

        if (uporDown <= 1)
            thrownDown = true;

        StartCoroutine(Timer());

        index = Random.Range(0, 4);
        if(index ==1)
        gameObject.GetComponent<SpriteRenderer>().sprite = redSprite;
        if (index == 2)
            gameObject.GetComponent<SpriteRenderer>().sprite = yellowSprite;
        if (index == 3)
            gameObject.GetComponent<SpriteRenderer>().sprite = orangeSprite;
        if (index == 4)
            gameObject.GetComponent<SpriteRenderer>().sprite = greySprite;

        if (!isSpark)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            }

        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -15);

        //StartCoroutine(Timer());

        if (thrownDown)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, -(Random.RandomRange(throwSpeedLow, throwSpeedHigh)), 0, ForceMode.Impulse);
            //gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -10, ForceMode.Impulse);

        }
        if (!thrownDown)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, (Random.RandomRange(throwSpeedLow, throwSpeedHigh)), 0, ForceMode.Impulse);
           // gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -10, ForceMode.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    IEnumerator Timer()
    {
        //Just in case theres an issue and it doesnt collide with anything. 
        yield return new WaitForSeconds(13);
        Destroy(gameObject);

    }


}
