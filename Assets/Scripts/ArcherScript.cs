using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArcherScript : MonoBehaviour
{

    public int startingHealth;
    int curHealth;
    public GameObject bloodSplatter;
    public bool walkingUp;
    public bool canSwitch = true;
    public bool playerSpotted;
    bool shooting;
    public Transform target;
    public GameObject upArrows;
    public GameObject downArrows;

    public int lookLength;
    public int arrowsShot;
    public int arrowsToShoot;

    AudioSource archerAudio;
    public AudioClip shootSound;
    public GameObject timerHolder;

    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        archerAudio = gameObject.GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        StartCoroutine(Timer());
        walkingUp = true;
        curHealth = startingHealth;
        archerAudio.clip = shootSound;
        timerHolder = GameObject.FindWithTag("TimerHolder");

    }

    // Update is called once per frame
    void Update()
    {

        if (!shooting)
        {
            RaycastHit hit;
            if (walkingUp)
            {
                Ray lookingRay = new Ray(transform.position, Vector3.down);
                Debug.DrawRay(transform.position, Vector3.down * lookLength);
                if (Physics.Raycast(lookingRay, out hit, lookLength))
                {
                    Debug.Log("The RaycastHitSomethingr");
                    if (hit.collider.tag == "PDA")
                    {
                        Debug.Log("The RaycastHitplayer");
                        arrowsShot = 0;
                        StartCoroutine(Timer2());
                    }
                }
            }
            if (!walkingUp)
            {
                Ray lookingRay = new Ray(transform.position, Vector3.up);
                Debug.DrawRay(transform.position, Vector3.up * lookLength);
                if (Physics.Raycast(lookingRay, out hit, lookLength))
                {
                    Debug.Log("The RaycastHitSomethingr");
                    if (hit.collider.tag == "PDA" && !shooting)
                    {
                        Debug.Log("The RaycastHitplayer");
                        arrowsShot = 0;
                        StartCoroutine(Timer2());
                    }
                }
            }



            Vector3 tempPos = new Vector3(0, target.position.y, 0);

            if (playerSpotted)
            {
                // transform.LookAt(tempPos);
            }

            Vector3 v = rigidBody.velocity;

            if (walkingUp)
            {
                rigidBody.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (!walkingUp)
            {
                rigidBody.rotation = Quaternion.Euler(0, 0, 180);

            }
        }
        if (curHealth <= 0)
        {
            Vector3 posX = transform.position;
            timerHolder.GetComponent<timer2>().filAmount += 0.4f;
            Destroy(gameObject);
            Instantiate(bloodSplatter, posX, transform.rotation);
            Instantiate(bloodSplatter, posX, transform.rotation);
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
        if (col.gameObject.tag == "Pitfall")
        {
            if (walkingUp)
                walkingUp = false;
            else if (!walkingUp)
                walkingUp = true;
        }



    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.25f);
        shooting = false;
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



    IEnumerator Timer2()
    {
       
                shooting = true;
             
             if (arrowsShot >= arrowsToShoot)
             {
                 
                 canSwitch = true;
             StartCoroutine(Timer());
                }

            if (arrowsShot <= arrowsToShoot)
            {
                canSwitch = false;
                archerAudio.PlayOneShot(shootSound, 1);
                yield return new WaitForSeconds(0.25f);
                Vector3 posX = transform.position;
                posX.y -= 1f;
                if (walkingUp)
                {
                    Instantiate(downArrows, posX, transform.rotation);
                }
                if (!walkingUp)
                {
                    Instantiate(upArrows, posX, transform.rotation);
                }
                arrowsShot += 1;
                yield return new WaitForSeconds(1);

                StartCoroutine(Timer2());
            }
            if (arrowsShot >= arrowsToShoot)
            {
                shooting = false;
                canSwitch = true;
                StartCoroutine(Timer());
            }
        }
}
