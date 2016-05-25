using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth;
    int curHealth;
    public GameObject bloodSplatter;
    float walkSpeed;
    public int actualWalkSpeed;
    public bool walkingUp;
    public bool canSwitch = true;
    public bool playerSpotted;
    public Transform target;
    public GameObject timerHolder;




    Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(Timer());
        walkingUp = true;
        curHealth = startingHealth;
        timerHolder = GameObject.FindWithTag("TimerHolder");

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tempPos = new Vector3(0, gameObject.GetComponent<Rigidbody>().position.y, 0);
        if (playerSpotted)
        {
           // transform.LookAt(tempPos);
        }

        Vector3 v = rigidBody.velocity;
        v.y = walkSpeed;
        rigidBody.velocity = v;
        walkSpeed = actualWalkSpeed;
        if (walkingUp)
        {
            rigidBody.rotation = Quaternion.Euler(0, 0, 0);
            walkSpeed = actualWalkSpeed;
        }
        if (!walkingUp)
        {
            rigidBody.rotation = Quaternion.Euler(0, 0, 180);
            walkSpeed = -actualWalkSpeed;
        }

        if (curHealth <= 0)
        {
            Vector3 posX = transform.position;
            Instantiate(bloodSplatter, posX, transform.rotation);
            Instantiate(bloodSplatter, posX, transform.rotation);
            timerHolder.GetComponent<timer2>().filAmount += 0.4f;
            Destroy(gameObject);
        }

        }

    void OnCollisionEnter(Collision col1)
    {
        if (col1.gameObject.tag == "Weapon")
        {
            Vector3 posX = transform.position;
            posX.y -= 0.75f;
                Instantiate(bloodSplatter, col1.gameObject.transform.position, transform.rotation);
                curHealth -= 10;
            
        }

    }


            void OnTriggerEnter(Collider col)
    {
        Vector3 posX = transform.position;
        if (col.gameObject.tag == "Weapon")
        {
            
            posX.y -= 0.75f;
            Instantiate(bloodSplatter, col.gameObject.transform.position, transform.rotation);
            curHealth -= 10;

        }

        if (col.tag == "Pitfall" || col.tag == "Enemy" || col.tag == "EnemyWeapon" || col.tag == "Geography")
        {
            if (walkingUp)
                walkingUp = false;
            else if (!walkingUp)
                walkingUp = true;
        }

        }

    IEnumerator Timer()
    {
       yield return new WaitForSeconds(Random.Range(1.5f, 5f));
        if (canSwitch)
        {
            if (walkingUp)
                walkingUp = false;
            else if (!walkingUp)
                walkingUp = true;

            StartCoroutine(Timer());
        }
    }

    IEnumerator CantSeeTimer()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 5f));

        canSwitch = true;

        StartCoroutine(Timer());
    }


}
