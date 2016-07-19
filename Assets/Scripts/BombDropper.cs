using UnityEngine;
using System.Collections;

public class BombDropper : MonoBehaviour {

    public GameObject theBombs;

    public int disUp;
    public int disDown;
    //Measure the units above the bomber placement that has level tiles. 
    //    i.e. If bomber placed at y.200, and the ground tiles go up to 500
    //    disUP would be '300'. Same gos for disDown. If the bottom ground tile
    //    goes down to, say, 50, disDown would be '150'



    public float firingTimer;

	// Use this for initialization
	void Start () {
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
	
	}



    IEnumerator Timer()
    {
       
        yield return new WaitForSeconds(firingTimer);
        Vector3 smoPOS = gameObject.transform.position;
        smoPOS.y += Random.RandomRange(disDown, disUp );
        GameObject instObject = Instantiate(theBombs, smoPOS, transform.rotation) as GameObject;
        instObject.GetComponent<BOMBscript>().timerLow = 2;
        instObject.GetComponent<BOMBscript>().timerHigh = 5;

        instObject.GetComponent<BOMBscript>().throwSpeedLow = 0;
        instObject.GetComponent<BOMBscript>().throwSpeedHigh = 0;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(Timer());
    }


}
