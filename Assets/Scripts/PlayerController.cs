using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using VideoGlitches;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float m_MaxSpeed = 5f;

    GameObject mainCamera;
    Vector3 camOriginalPosition;
    Vector3 camNewPosition;

    public Sprite upSprite;
    public Sprite downSprite;
    SpriteRenderer playerSpriteRen;
    Vector3 gravity;
    Rigidbody rigidBody;
    float walkSpeed;
    public int actualWalkSpeed;
    public int jumpForce;
    private float startWalkSpeed;
    bool falling;
    bool canControl = true;
    public bool canJump;
    bool facingDown;

    public GameObject sword;

    public AudioSource walkingSource;
    public AudioSource weaponSource;
    public AudioClip walkingSound;
    public AudioClip stabbingSound;
    public AudioSource hitTakenSource;
    public AudioClip fallingClip;
    
    public AudioClip arrowHitSound;
    public AudioClip jumpSound;
    public AudioClip landingSound;
    public AudioClip teleIn;
    public AudioClip teleOut;
    public AudioClip LavaContact;


    public GameObject bloodSplatter;

    public float maxhealth;
    float curHealth;
    public Image healthBar;
    public GameObject healthEffectHolder;
   

    private Animator anim;
    AudioSource audio1;

    bool stopWalking;
    Vector3 v;

    public GameObject playerLaserUp;
    public GameObject playerLaserDown;

    private int laserShots = 4;
    private int lasersShot;
    public GameObject laserCounter;
     SpriteRenderer playerLaserImage;
    public Sprite laser4;
    public Sprite laser3;
    public Sprite laser2;
    public Sprite laser1;
    public Sprite laser0;
    public AudioSource laserRecharge;
    public AudioClip laserFiringSound;

    public GameObject lavaExplosion;
    public bool inLava;
    public bool flatLevel;
    public bool canHighlight = false;

    GameObject[] highlighter;

    public bool lastLevel;
    

    // Use this for initialization
    void Start () {

        playerLaserImage = laserCounter.GetComponent<SpriteRenderer>();
        
        rigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        curHealth = maxhealth;
        audio1 = GetComponent<AudioSource>();
        sword.tag = "Untagged";
        weaponSource.clip = teleIn;
        weaponSource.Play();
        lasersShot = laserShots;
        playerSpriteRen = gameObject.GetComponent<SpriteRenderer>();
        playerSpriteRen.sprite = upSprite;

        mainCamera = GameObject.FindWithTag("MainCamera");
        highlighter = GameObject.FindGameObjectsWithTag ("Highlighter");

    }
	
	// Update is called once per frame
	void Update () {

        if (canJump )
        {
            foreach (GameObject highlighters in highlighter)
            {
                highlighters.GetComponent<Collider>().enabled = false;
            }
        }

        if (!canJump && canHighlight)
        {
            foreach (GameObject highlighters in highlighter)
            {
                highlighters.GetComponent<Collider>().enabled = true;
            }
        }

        if (facingDown)
        {
            playerSpriteRen.sprite = downSprite;
            laserCounter.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (!facingDown)
        {
            playerSpriteRen.sprite = upSprite;
            laserCounter.transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        if (transform.position.z >= 1500 )
        {
            StartCoroutine(Timer());
           }

        if (transform.position.z >= 50 && flatLevel)
        {
            StartCoroutine(Timer());
        }






        if (Input.GetKey(KeyCode.Escape))
        {
        if(Application.loadedLevel == 0)
            Application.Quit();
            if (Application.loadedLevel != 0)
                Application.LoadLevel(1);
        }

        if (!canJump)
        {
           // actualWalkSpeed = actualWalkSpeed / 2;

        }

        Vector3 v = rigidBody.velocity;
        //rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

        v.y = walkSpeed;
        //rigidBody.velocity = v;
  
        
        if (canControl)
        {
            if (Input.GetButton("w"))
            {
                v.y = actualWalkSpeed * m_MaxSpeed;
                rigidBody.velocity = new Vector3(v.x, v.y, v.z);
                //rigidBody.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Walking", true);
                facingDown = false;
                walkingSource.clip = walkingSound;
               
                if (!audio1.isPlaying && canJump)
                    GetComponent<AudioSource>().Play();
            }

            if (Input.GetButton("s"))
            {
                v.y = -actualWalkSpeed * m_MaxSpeed;
                rigidBody.velocity = new Vector3(v.x, v.y, v.z);
                facingDown = true;
                
                if (!audio1.isPlaying && canJump)
                    GetComponent<AudioSource>().Play();
            }

            if (Input.GetButtonUp("w") || Input.GetButtonUp("s"))
            {

                
                walkSpeed = 0;
                anim.SetBool("Walking", false);
                walkingSource.Stop();
                stopWalking = true;
                v = rigidBody.velocity;
                
                 rigidBody.velocity = new Vector3(v.x, v.y, v.z);
                

            }
            
            if (stopWalking)
            {
                if (rigidBody.velocity.y >= 1)
                {
                    v = rigidBody.velocity;
                    v.y -= 1.1f;
                    rigidBody.velocity = new Vector3(v.x, v.y, v.z);
                    if (rigidBody.velocity.y <= 0)
                    {
                        stopWalking = false;
                    }
                }

                if (rigidBody.velocity.y <= -1)
                {
                    v = rigidBody.velocity;
                    v.y += 1.1f;
                    rigidBody.velocity = new Vector3(v.x, v.y, v.z);
                    if (rigidBody.velocity.y >= 0)
                    {
                        stopWalking = false;
                    }
                }
            }

            if (Input.GetButtonDown("e"))
            {
                Vector3 posX = transform.position;

                if (!facingDown)
                {
                    if (laserShots > 0)
                    {
                        AudioSource laserSource = gameObject.AddComponent<AudioSource>();
                        laserSource.clip = laserFiringSound;
                        laserSource.Play();
                        posX.y += 1f;
                        Instantiate(playerLaserUp, posX, transform.rotation);
                        laserShots -= 1;
                    }
                }
                if (facingDown)
                {
                    if (laserShots > 0)
                    {
                        weaponSource.clip = laserFiringSound;
                        weaponSource.Play();
                        posX.y -= 1f;
                        Instantiate(playerLaserDown, posX, transform.rotation);
                        laserShots -= 1;
                    }
                }
            }

            if (laserShots == 4)
                playerLaserImage.sprite = laser4;
            if (laserShots == 3)
                playerLaserImage.sprite = laser3;
            if (laserShots == 2)
                playerLaserImage.sprite = laser2;
            if (laserShots == 1)
                playerLaserImage.sprite = laser1;
            if (laserShots == 0)
                playerLaserImage.sprite = laser0;

            if(laserShots < lasersShot)
            {
                if (!laserRecharge.isPlaying)
                {
                    laserRecharge.Play();
                    StartCoroutine(Timer3());
                }


            }


            if (Input.GetButtonDown("r"))
            {
                if(!facingDown)
                anim.SetBool("Striking", true);
                if (facingDown)
                    anim.SetBool("StrikingDown", true);
                weaponSource.clip = stabbingSound;
                weaponSource.Play();
                sword.tag = "Weapon";
            }

            if (Input.GetButtonUp("r"))
            {
                sword.tag = "Untagged";
                anim.SetBool("Striking", false);
                anim.SetBool("StrikingDown", false);
            }

            if (Input.GetButtonDown("Jump"))
            {
                if(canJump)
                rigidBody.velocity = new Vector3(v.x, v.y, -jumpForce);
                hitTakenSource.clip = jumpSound;
                if(canJump)
                hitTakenSource.Play();
            }

            if (Input.GetButtonUp("Jump"))
            {

            }
        }

        if(curHealth >=100)
        {

            Application.LoadLevel(Application.loadedLevel);
        }


        if(!canJump)
            GetComponent<AudioSource>().Stop();



        if (inLava){

            Vector3 posX = transform.position;
            posX.y += Random.RandomRange(-2, 2);
            Instantiate(lavaExplosion, posX, transform.rotation);
        }

        if (rigidBody.velocity.z < 15)
        {
            hitTakenSource.clip = fallingClip;
            hitTakenSource.Play();
        }

        }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "HF")
        {
            canHighlight = true;
        }


            if (col.gameObject.tag == "Pitfall")
        {
            walkingSource.Stop();
            anim.SetBool("Striking", false);
            anim.SetBool("StrikingDown", false);
            rigidBody.velocity = new Vector3(0,0,0);
            canControl = false;
            Vector3 pfPos = col.transform.position;
            rigidBody.transform.position = pfPos;
            walkSpeed = 0;
            anim.SetBool("Walking", false);
            anim.SetBool("Falling", true);
            StartCoroutine(Timer());
        }

        if (col.gameObject.tag == "EnemyWeapon")
        {
           
            curHealth += 10;
            float calcHealth = curHealth / maxhealth;
            setHealth(calcHealth);
            Vector3 posX = transform.position;
            Instantiate(bloodSplatter, posX, transform.rotation);
            healthEffectHolder.GetComponent<VideoGlitchOldVHS>().amount += 0.10f;

        }

        if (col.gameObject.tag == "Arrow")
        {
            hitTakenSource.clip = arrowHitSound;
            hitTakenSource.Play();
            curHealth += 5;
            float calcHealth = curHealth / maxhealth;
            setHealth(calcHealth);
            Destroy(col.gameObject);
            Vector3 posX = transform.position;
            Instantiate(bloodSplatter, posX, transform.rotation);
            healthEffectHolder.GetComponent<VideoGlitchOldVHS>().amount += 0.20f;


        }

        if (col.gameObject.tag == "Exit")
        {
            walkingSource.Stop();
           //int curLevel = PlayerPrefs.GetInt("HighestLevelUnlocked");
           // curLevel += 1;
            anim.SetBool("Striking", false);
            anim.SetBool("StrikingDown", false);
            rigidBody.velocity = new Vector3(0, 0, 0);
            canControl = false;
            Vector3 pfPos = col.transform.position;
            rigidBody.transform.position = pfPos;
            walkSpeed = 0;
            anim.SetBool("Walking", false);
            anim.SetBool("Falling", true);
            PlayerPrefs.SetInt("HighestLevelUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(Timer2());

            
            
        }

        }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "HF")
        {
            canHighlight = false;
        }

    }

        void OnCollisionStay(Collision col3)
    {
        canJump = true;
    }


        void OnCollisionEnter(Collision col1)
    {

        if (col1.gameObject.tag == "EnemyWeapon")
        {

            curHealth += 10;
            float calcHealth = curHealth / maxhealth;
            setHealth(calcHealth);
            Vector3 posX = transform.position;
            Instantiate(bloodSplatter, posX, transform.rotation);
            healthEffectHolder.GetComponent<VideoGlitchOldVHS>().amount += 0.10f;

        }

        if (col1.gameObject.tag == "Lava")
        {
            inLava = true;
            canControl = false;
            walkingSource.clip = LavaContact;
            walkingSource.Play();
            Debug.Log("Thumbs up John Connor");
            StartCoroutine(LavaTimer());
        }


            if (gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 0f)
        {
            hitTakenSource.clip = landingSound;
            hitTakenSource.Play();

        }

        //if (col1.gameObject.tag == "ground" /*|| col1.gameObject.tag == "Geography"*/)
        //{
        
            canJump = true;
       // }

        }

    void OnCollisionExit(Collision col2)
    {
       // if (col2.gameObject.tag == "ground")
       // {
            canJump = false;
        //}
        }

    void setHealth (float calcHealth)
    {

       // healthBar.fillAmount = calcHealth;
    }
    IEnumerator Timer()
    {
        
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(Application.loadedLevel);

    }

    IEnumerator LavaTimer()
    {

        yield return new WaitForSeconds(2f);
        Application.LoadLevel(Application.loadedLevel);

    }

    IEnumerator Timer2()
    {
        weaponSource.clip = teleOut;
        weaponSource.Play();

        
        yield return new WaitForSeconds(0.75f);
        if (!lastLevel)
        {
            Application.LoadLevel(Application.loadedLevel);
            Application.LoadLevel(Application.loadedLevel + 1);

        }

        if (lastLevel)
        {
            Application.LoadLevel(1);

        }
    }

    IEnumerator Timer3()
    {

        yield return new WaitForSeconds(4f);
        laserShots += 1;
    }



    }

