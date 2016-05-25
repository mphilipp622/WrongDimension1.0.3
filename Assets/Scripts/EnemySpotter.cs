using UnityEngine;
using System.Collections;

public class EnemySpotter : MonoBehaviour
{

    public GameObject enemyObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name == "PDA")
        {
           // enemyObject = col.GetComponent<GameObject>();
//            enemyObject.GetComponent<EnemyHealth>().playerSpotted = true; //Needs to be updated. EnemyHealth is now SwordsmanScript
            //GameObject colObject = col.GetComponent<gameObject>();
            if (col.transform.position.y <= gameObject.transform.position.y)
                Debug.Log("Its below the bad guy");
            if (col.transform.position.y >= gameObject.transform.position.y)
                Debug.Log("Its above the bad guy");
        }

    }

}
