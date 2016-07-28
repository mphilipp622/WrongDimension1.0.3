using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using com.ootii.Input;

public class Mainmenu : MonoBehaviour {

    // public GameObject mainMenuPanel;
    Animator MainMenuAnim;

	Event keyEvent;

    public GameObject MenuCanvas;
    public GameObject[] MainMenuSelect;
    public GameObject[] LevelSelects;
    public GameObject[] optionsSelects;
    
    public float speed = 2.0f;

    private Vector3 MaintargetScale;
    private Vector3 LevtargetScale;
    private Vector3 options1Scale;
    
    private Vector3 baseScale;
    private Vector3 LevbaseScale;
    private Vector3 options1baseScale;
    private int currScale;

    private bool mainMenuGone = false;
    private bool levelSelecting = false;

    [Tooltip("Make true, play game. Stop game, then make false. Clears save data")]
    public bool resetLevels;

    public int levelsUnlocked;

    public bool alreadyoptions;


    /// /////////////////////////////////////
    AudioMixer gameMixer;
    AudioMixer musicMixer;
    public AudioMixerSnapshot gameAllDown;
    public AudioMixerSnapshot gamethirdUp;
    public AudioMixerSnapshot gamehalfUp;
    public AudioMixerSnapshot gamethreefourthUp;
    public AudioMixerSnapshot gameFull;


    public AudioMixerSnapshot musicAllDown;
    public AudioMixerSnapshot musicthirdUp;
    public AudioMixerSnapshot musichalfUp;
    public AudioMixerSnapshot musicthreefourthUp;
    public AudioMixerSnapshot musicFull;

    //public GameObject gameVolume;
    public GameObject gameButton;

    public int gameVolInt = 3;
    public Sprite[] gameVolSprites;

    public GameObject musicVolume;
    public GameObject musicButton;
    float musicVolLevel;
    public int musicVolInt = 3;
    public Sprite[] musicVolSprites;

	bool waitingForKey = false;
	Animator panelAnim;

    // Use this for initialization
    void Start () {

		panelAnim = MenuCanvas.GetComponent<Animator>();

        // MainMenuAnim = mainMenuPanel.GetComponent<Animator>();
        baseScale = transform.localScale;
        MaintargetScale = baseScale;
        
        foreach (GameObject obj2 in LevelSelects)
        {
            LevbaseScale.x = 0.14f;
            LevtargetScale = obj2.transform.localScale;
            //obj2.transform.localScale = new Vector3(LevbaseScale.x, LevbaseScale.y, LevbaseScale.z);
        }

        foreach (GameObject obj3 in optionsSelects)
        {
            // options1Scale.y = 0.5f;

            obj3.transform.localScale = new Vector3 (1, 0, 1);

        }


        if (resetLevels)
        {
            PlayerPrefs.SetInt("HighestLevelUnlocked", 2);
            levelsUnlocked= PlayerPrefs.GetInt("HighestLevelUnlocked");
            resetLevels = false;
        }


        musicVolume = GameObject.FindWithTag("MusicHandler");
        musicVolume.GetComponent<AudioSource>().volume = musicVolLevel;
        musicVolLevel = musicVolume.GetComponent<MusicHanlder>().musicVol;
        musicVolInt = musicVolume.GetComponent<MusicHanlder>().musicVolint;

        //////////////////////////////
        if (musicVolInt == 0)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[0];
            //musicVolume.GetComponent<MusicHanlder>().musicVolint = 0;
            musicAllDown.TransitionTo(0.5f);
            // musicVolLevel = 0.0f;

        }

        if (musicVolInt == 1)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[1];
            //musicVolume.GetComponent<MusicHanlder>().musicVolint = 1;
            //musicVolLevel = 0.33f;
            musicthirdUp.TransitionTo(0.5f);




        }

        if (musicVolInt == 2)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[2];
            //musicVolume.GetComponent<MusicHanlder>().musicVolint = 2;
            //musicVolLevel = 0.66f;
            musichalfUp.TransitionTo(0.5f);
        }

        if (musicVolInt == 3)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[3];
            //musicVolume.GetComponent<MusicHanlder>().musicVolint = 3;
            //musicVolLevel = 1f;
            musicFull.TransitionTo(0.5f);

        }
        /////////////////////////////
		/// 

    }
	
	// Update is called once per frame
	void Update () {

//		Debug.Log(InputManager.GetValue("Forward"));
//		Debug.Log(InputManager.IsPressed(179));
       // musicVolume.GetComponent<AudioSource>().volume = 1;

        levelsUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked");

        foreach (GameObject obj in MainMenuSelect)
            {
                MaintargetScale.y = 0.5f;
            
                obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, MaintargetScale, speed * Time.deltaTime);
                
            }


        foreach (GameObject obj3 in optionsSelects)
        {
           options1Scale.x = 1f;

            obj3.transform.localScale = Vector3.Lerp(obj3.transform.localScale, options1Scale, speed * Time.deltaTime);

        }


        //if (transform.localScale != LevtargetScale)
        //{

        foreach (GameObject obj2 in LevelSelects)
            {
                //MaintargetScale.x = baseScale.x;
                obj2.transform.localScale = Vector3.Lerp(obj2.transform.localScale, LevtargetScale, speed * Time.deltaTime);
                //StartCoroutine(Timer());
            }
        
        //}


    }

//	void OnGUI()
//	{
//		/*keyEvent dictates what key our user presses
//		 * by using Event.current to detect the current
//		 * event
//		 */
//		keyEvent = Event.current;
//
//		//Executes if a button gets pressed and
//		//the user presses a key
//		if(keyEvent.isKey && waitingForKey)
//		{
//			newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
//			waitingForKey = false;
//		}
//	}

    public void GameStart()
    {
        //MainMenuAnim.SetBool("PickingLevel", true);
        gameObject.GetComponent<AudioSource>().Play();
        Debug.Log("Should be shrinking");
            MaintargetScale.x = 0;
        StartCoroutine(Timer());


    }

    public void optionsMenu()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (alreadyoptions == false)
        {
            MaintargetScale.x = 0;
            StartCoroutine(OptionsTimer());
            
        } else if  (alreadyoptions == true)
        {
           
            StartCoroutine(OptionsTimer2());
           
        }



    }


    public void GameExit()
    {
        Application.Quit();

    }

    
    public void ChangeMusicVol()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (musicVolInt >= 3)
        {
            musicVolInt = 0;
        } else if (musicVolInt < 3)
        {
            musicVolInt++;
        }


        if (musicVolInt == 0)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[0];
            musicAllDown.TransitionTo(0.5f);
           

        }

        if (musicVolInt == 1)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[1];
             musicthirdUp.TransitionTo(0.5f);
            
        }

        if (musicVolInt ==2)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[2];
            musichalfUp.TransitionTo(0.5f);
        }

        if (musicVolInt == 3)
        {
            musicButton.GetComponent<Image>().sprite = musicVolSprites[3];
            musicFull.TransitionTo(0.5f);

        }
        }

    public void ChangeGameVol()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (gameVolInt >= 3)
        {
            gameVolInt = 0;
        }
        else if (gameVolInt < 3)
        {
            gameVolInt++;
        }


        if (gameVolInt == 0)
        {
            gameButton.GetComponent<Image>().sprite = gameVolSprites[0];
            gameAllDown.TransitionTo(0.5f);


        }

        if (gameVolInt == 1)
        {
            gameButton.GetComponent<Image>().sprite = gameVolSprites[1];
            gamethirdUp.TransitionTo(0.5f);
        }

        if (gameVolInt == 2)
        {
            gameButton.GetComponent<Image>().sprite = gameVolSprites[2];
            gamehalfUp.TransitionTo(0.5f);
        }

        if (gameVolInt == 3)
        {
            gameButton.GetComponent<Image>().sprite = gameVolSprites[3];
            gameFull.TransitionTo(0.5f);

        }
    }

    public void StartKeyMapping()
    {
        panelAnim.SetBool("MappingUp", true);
		StartCoroutine(KeyMapping());
    }

	IEnumerator KeyMapping()
	{
		GameObject eventSystem = GameObject.Find("EventSystem");
		eventSystem.SetActive(false);

		waitingForKey = true;

		yield return WaitForKey("Forward");
		panelAnim.SetBool("MappingUp", false);
		panelAnim.SetBool("MappingDown", true);
		yield return new WaitForSeconds(panelAnim.GetCurrentAnimatorStateInfo(0).length);

		waitingForKey = true;

		yield return WaitForKey("Back");
		panelAnim.SetBool("MappingDown", false);
		panelAnim.SetBool("MappingJump", true);
		yield return new WaitForSeconds(panelAnim.GetCurrentAnimatorStateInfo(0).length);

		waitingForKey = true;

		yield return WaitForKey("Jump");
		panelAnim.SetBool("MappingJump", false);
		panelAnim.SetBool("MappingMelee", true);
		yield return new WaitForSeconds(panelAnim.GetCurrentAnimatorStateInfo(0).length);

		waitingForKey = true;

		yield return WaitForKey("Melee");
		panelAnim.SetBool("MappingMelee", false);
		panelAnim.SetBool("MappingLaser", true);
		yield return new WaitForSeconds(panelAnim.GetCurrentAnimatorStateInfo(0).length);

		waitingForKey = true;

		yield return WaitForKey("Shoot");
		panelAnim.SetBool("MappingLaser", false);
		yield return new WaitForSeconds(panelAnim.GetCurrentAnimatorStateInfo(0).length);
		eventSystem.SetActive(true);
	}

	IEnumerator WaitForKey(string inputName)
	{
		while(waitingForKey)
		{
			for(int i = EnumInput.GAMEPAD_MIN; i <= EnumInput.GAMEPAD_MAX; i++)
			{
				if(InputManager.IsJustPressed(i))
				{
					Debug.Log("Testing Controller");
					InputManager.RemoveAlias(inputName);
					InputManager.AddAlias(inputName + "Xbox", i);
					PlayerPrefs.SetInt(inputName + "Xbox", i);
					yield return null;
					waitingForKey = false;
				}
			}
			for(int i = EnumInput.KEYBOARD_MIN; i <= EnumInput.KEYBOARD_MAX; i++)
			{
				if(InputManager.IsJustPressed(i))
				{
					Debug.Log("Testing Keyboard");
					InputManager.RemoveAlias(inputName);
					InputManager.AddAlias(inputName + "Keyboard", i);
					PlayerPrefs.SetInt(inputName + "Keyboard", i);
					yield return null;
					waitingForKey = false;
				}
			}
			yield return null;
		}
	}

	public void UseGamepad()
	{
		InputManager.UseGamepad = true;
	}

	public void UseKeyboard()
	{
		InputManager.UseGamepad = false;
	}

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(0.75f);
        
        LevtargetScale.y = 1f;
        Debug.Log("Level Select");
    }


    IEnumerator OptionsTimer()
    {
        alreadyoptions = true;
        yield return new WaitForSeconds(0.75f);

       options1Scale.y = 1.5f;
        Debug.Log("Options Select");
    }

    IEnumerator OptionsTimer2()
    {
        speed = 12;
        alreadyoptions = false;
        options1Scale.y = 0f;
        yield return new WaitForSeconds(0.75f);
        speed = 8;
        MaintargetScale.x = 1;
        Debug.Log("Go back to menu");
        

    }
}
