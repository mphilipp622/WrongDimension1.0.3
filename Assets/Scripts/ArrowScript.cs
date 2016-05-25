using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

    Rigidbody myRig;
    Vector3 v;
    public float arrowSpeed;
	//int layerMask;

    // Use this for initialization
    void Start () 
	{
        myRig = gameObject.GetComponent<Rigidbody>();
        v = myRig.velocity;
        v.y -= arrowSpeed;
		myRig.velocity = v;
        StartCoroutine(Timer());

    }
	
	// Update is called once per frame
	void Update () 
	{
		//Detect if arrow has gone significantly out of camera boundary. If it has, destroy the arrow
		//if(transform.position.y < Camera.main.rect.min.y - 100 || transform.position.y > Camera.main.rect.max.y + 100)
			
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col1)
    {
        //if (col1.gameObject.tag == "ground" || col1.gameObject.tag == "Geography" || col1.gameObject.tag == "Enemy")
        //{
            Destroy(gameObject);
       // }

    }


        }
