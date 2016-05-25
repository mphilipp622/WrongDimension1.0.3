using UnityEngine;
using System.Collections;

public class BomberScript : MonoBehaviour {

    public GameObject bombs;
    public GameObject bloodSplatter;
    

    public bool walkingUp;

    public int startingHealth;
    public int curHealth;
    float walkSpeed;
    public int actualWalkSpeed;
    public bool canSwitch = true;
    bool bombing = false;
    public int lookLength;
     int bombsThrown;
    public int bombsToThrow;
    public GameObject timerHolder;

    Rigidbody rigidBody;

    public AudioClip throwSound;

    bool canBomb = true;

    // Use this for initialization
    void Start () {
        curHealth = startingHealth;
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(Timer());
        timerHolder = GameObject.FindWithTag("TimerHolder");

    }

    // Update is called once per frame
    void Update()
    {
        if (!bombing)
        {

            RaycastHit hit;

            if (!walkingUp)
            {
                Ray lookingRay = new Ray(transform.position, Vector3.down);
                Debug.DrawRay(transform.position, Vector3.down * lookLength);
                if (Physics.Raycast(lookingRay, out hit, lookLength))
                {
                    Debug.Log("The RaycastHitSomethingr");
                    if (hit.collider.tag == "PDA")
                    {
                        StartCoroutine(Timer2());
                        bombsThrown = 0;
                        bombing = true;
                    }
                }
                
            }

            if (walkingUp)
            {
                Ray lookingRay = new Ray(transform.position, Vector3.up);
                Debug.DrawRay(transform.position, Vector3.up * lookLength);
                if (Physics.Raycast(lookingRay, out hit, lookLength))
                {
                    Debug.Log("The RaycastHitSomethingr");
                    if (hit.collider.tag == "PDA")
                    {
                        StartCoroutine(Timer2());
                        bombsThrown = 0;
                        bombing = true;
                    }
                }
            }




            Vector3 tempPos = new Vector3(0, gameObject.transform.position.y, 0);
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

            

        }

        if (curHealth <= 0)
        {
            Vector3 posX = transform.position;
            Instantiate(bloodSplatter, posX, transform.rotation);
            Instantiate(bloodSplatter, posX, transform.rotation);
            timerHolder.GetComponent<timer2>().filAmount += 0.8f;
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
        
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        if (canSwitch)
        {
            if (walkingUp)
                walkingUp = false;
            else if (!walkingUp)
                walkingUp = true;

            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer2()
    {
        if (bombsThrown < bombsToThrow)
        {
    
            yield return new WaitForSeconds(0.75f);
            Vector3 bLoc;
            bLoc = gameObject.GetComponent<Rigidbody>().position;
            bLoc.x = 0;
            Instantiate(bombs,transform.position, transform.rotation);
            gameObject.GetComponent<AudioSource>().clip = throwSound;
            gameObject.GetComponent<AudioSource>().Play();
            bombsThrown += 1;
            StartCoroutine(Timer2());
        }
        if(bombsThrown>= bombsToThrow)
        {
            bombing = false;
            yield return new WaitForSeconds(2);
            canBomb = true;
            bombsThrown = 0;
        }

    }

    
    }
