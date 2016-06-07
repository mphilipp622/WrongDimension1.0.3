using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BullScript : MonoBehaviour
{

    public int startingHealth;
    int curHealth;
    public GameObject bloodSplatter;
    float walkSpeed;
    public int actualWalkSpeed;
    public bool walkingUp;
    public bool canSwitch = true;
    public bool playerSpotted;
    public Transform target;
    public int chargeSpeed;
	bool charging, isCharged;
    public GameObject timerHolder;

    public AudioSource chargingSource;
    public AudioClip chargingSound;

    public int lookLength;

	[SerializeField]
	[Tooltip("Dictates range of randomization for Timer, which switches enemy direction. lowTimer is the lowest value of randomization, highTimer is highest value.")]
	float lowTimer, highTimer;

	[SerializeField]
	[Tooltip("Length of time in seconds that bull will charge player")]
	float chargeDuration;

	[SerializeField]
	[Tooltip("Dictates how long bull stands still before charging player. chargeTimeLow is the lowest value for randomization range and chargeTimeHigh is highest value")]
	float chargeTimeLow, chargeTimeHigh; // used for dictating charging distance, and time it takes to charge



	Vector3 v; //Used for determining velocity of the bull

    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        walkingUp = true;
		charging = false;
		isCharged = false;
        curHealth = startingHealth;
		v = rigidBody.velocity;
		StartCoroutine(Timer());
        timerHolder = GameObject.FindWithTag("TimerHolder");
    }

    // Update is called once per frame
    void Update()
    {

        if (!charging)
		{
			v.y = walkSpeed;
			rigidBody.velocity = v;
			walkSpeed = actualWalkSpeed;

			RaycastHit hit;
		
	        if (walkingUp)
	        {
				rigidBody.rotation = Quaternion.Euler(0, 0, 180);
				walkSpeed = actualWalkSpeed;

				Ray lookingRay = new Ray(transform.position, Vector3.up);
				Debug.DrawRay(transform.position, Vector3.up * lookLength, Color.red, .1f);
	            if (Physics.Raycast(lookingRay, out hit, lookLength))
	            {
	               // Debug.Log("The RaycastHitSomethingr");
	                if (hit.collider.tag == "PDA")
	                {
	                //    Debug.Log("The RaycastHitplayer");
	                    StartCoroutine(ChargeAttack());
	                }
	            }
	        }
	        else if (!walkingUp)
	        {
				rigidBody.rotation = Quaternion.Euler(0, 0, 0);
				walkSpeed = -actualWalkSpeed;

	            Ray lookingRay = new Ray(transform.position, Vector3.down);
				Debug.DrawRay(transform.position, Vector3.down * lookLength, Color.red);
	            if (Physics.Raycast(lookingRay, out hit, lookLength))
	            {
	               // Debug.Log("The RaycastHitSomethingr");
	                if (hit.collider.tag == "PDA")
	                {
	                //    Debug.Log("The RaycastHitplayer");
	                    StartCoroutine(ChargeAttack());
	                }
	            }
	        }
	    }
		else if(charging)
		{
			if(walkingUp && isCharged)
			{
				v.y = chargeSpeed;
				rigidBody.velocity = v;
			}
			else if(!walkingUp && isCharged)
			{
				v.y = -chargeSpeed;
				rigidBody.velocity = v;
			}
		}

        if (curHealth <= 0)
        {
            Vector3 posX = transform.position;
			Instantiate(bloodSplatter, posX, transform.rotation);
			Instantiate(bloodSplatter, posX, transform.rotation);
            timerHolder.SendMessage("BullKilled");
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

		if (col.tag == "Weapon" )
        {
			Debug.Log("WeaponBull" + curHealth);
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
        yield return new WaitForSeconds(Random.Range(3f, 6f));
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

    IEnumerator ChargeAttack()
    {
        charging = true;
        canSwitch = false;
        Vector3 v = rigidBody.velocity;
        if (walkingUp)
        { 
            v.y = 0;
            chargingSource.clip = chargingSound;
            chargingSource.Play();
			yield return new WaitForSeconds(Random.Range(chargeTimeLow, chargeTimeHigh)); // set chargeTimeLow and chargeTimeHigh in Editor. How long bull stands before charging
			isCharged = true; //Need this to ensure bull charges for full duration. Refer to Update()
            v.y = chargeSpeed;
            rigidBody.velocity = v;
			yield return new WaitForSeconds(chargeDuration); //How long the bull charges
			isCharged = false; //Controls movement in Update()
            v.y = actualWalkSpeed;
            rigidBody.velocity = v;
            yield return new WaitForSeconds(1);
            chargingSource.Stop();
            charging = false;
			walkingUp = false; //Make bull turn the opposite direction after it's charged
            canSwitch = true;
        }

        if (!walkingUp)
        {
            v.y = 0;
            chargingSource.clip = chargingSound;
            chargingSource.Play();
			yield return new WaitForSeconds(Random.Range(chargeTimeLow, chargeTimeHigh)); // set chargeTimeLow and chargeTimeHigh in Editor. How long bull stands before charging
			isCharged = true; //Need this to ensure bull charges for full duration. Refer to Update()
			v.y = -chargeSpeed;
            rigidBody.velocity = v;
			yield return new WaitForSeconds(chargeDuration); //How long bull charges.
			isCharged = false; //Used for controlling movement in Update()
            v.y = actualWalkSpeed;
            rigidBody.velocity = v;
            yield return new WaitForSeconds(1);
            chargingSource.Stop();
            charging = false;
			walkingUp = true; // Turn opposite direction after charging
            canSwitch = true;
        }

    }

}
