using UnityEngine;
using System.Collections;

public class upArrow : MonoBehaviour
{ 
    Rigidbody myRig;
    Vector3 v;
    public float arrowSpeed;

// Use this for initialization
void Start()
{

        myRig = gameObject.GetComponent<Rigidbody>();
    v = myRig.velocity;
    v.y += arrowSpeed;
    myRig.velocity = new Vector3(v.x, v.y, v.z);
        StartCoroutine(Timer());

    }

// Update is called once per frame
void Update()
{

}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col1)
    {
        // if (col1.gameObject.tag == "Geography" || col1.gameObject.tag == "Enemy")
        // { 
       // Debug.Log("DYEING");
            Destroy(gameObject);
       // }

    }
}
