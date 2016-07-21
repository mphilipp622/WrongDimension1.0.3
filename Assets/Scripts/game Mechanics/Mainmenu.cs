using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour {

    

    // public GameObject mainMenuPanel;
    Animator MainMenuAnim;

    public GameObject[] MainMenuSelect;
    public GameObject[] LevelSelects;
    public GameObject[] optionsSelects;
	public GameObject[] keymapSelects;
    
    public float speed = 2.0f;

    private Vector3 MaintargetScale;
    private Vector3 LevtargetScale;
    private Vector3 options1Scale;
	private Vector3 keymapScale;
    
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

	//Keymapping Variables
	Transform keymapPanel;
	Event keyEvent;
	Text buttonText;
	KeyCode newKey;
	Text[] textBoxes;

	bool waitingForKey, keymapOpen;

    // Use this for initialization
    void Start () {
        // MainMenuAnim = mainMenuPanel.GetComponent<Animator>();
        baseScale = transform.localScale;
        MaintargetScale = baseScale;

		musicVolume = GameObject.FindWithTag("MusicHandler");
		musicVolume.GetComponent<AudioSource>().volume = musicVolLevel;
		musicVolLevel = musicVolume.GetComponent<MusicHanlder>().musicVol;
		musicVolInt = musicVolume.GetComponent<MusicHanlder>().musicVolint;
        
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

		foreach (GameObject obj4 in keymapSelects)
		{
			// options1Scale.y = 0.5f;

			obj4.transform.localScale = new Vector3 (1, 0, 1);

		}


        if (resetLevels)
        {
            PlayerPrefs.SetInt("HighestLevelUnlocked", 2);
            levelsUnlocked= PlayerPrefs.GetInt("HighestLevelUnlocked");
            resetLevels = false;
        }


        

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
		/// Keymapping instantiation
		keymapPanel = GameObject.Find("KeymappingPanel").transform;
//		keymapPanel.gameObject.SetActive(false);
		waitingForKey = false;
		keymapOpen = false;

		for(int i = 0; i < 5; i++)
		{
			if(keymapPanel.GetChild(i).name == "DownKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.down.ToString();
			else if(keymapPanel.GetChild(i).name == "UpKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.up.ToString();
			else if(keymapPanel.GetChild(i).name == "JumpKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.jump.ToString();
			else if(keymapPanel.GetChild(i).name == "SwordKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.stab.ToString();
			else if(keymapPanel.GetChild(i).name == "GunKey")
				keymapPanel.GetChild(i).GetComponentInChildren<Text>().text = GameManager.GM.shoot.ToString();
		}
    }
	
	// Update is called once per frame
	void Update () {

        musicVolume.GetComponent<AudioSource>().volume = 1;


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

		foreach (GameObject obj4 in keymapSelects)
		{
			keymapScale.x = 1f;

			obj4.transform.localScale = Vector3.Lerp(obj4.transform.localScale, keymapScale, speed * Time.deltaTime);

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

	/// Keymapping Functions

	void OnGUI()
	{
		//		if(waitingForKey)
		keyEvent = Event.current;

		if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode;
			waitingForKey = false;
		}
	}

	public void OpenKeymapPanel()
	{
		gameObject.GetComponent<AudioSource>().Play();

		if(!keymapOpen)
		{
//			keymapPanel.gameObject.SetActive(true);
			options1Scale.y = 0;
			alreadyoptions = false;
			StartCoroutine(KeymapTimer());
		}
		else
		{
//			keymapPanel.gameObject.SetActive(false);
			StartCoroutine(KeymapTimer2());
		}
	}

	public void StartAssignment(string keyName)
	{
		if(!waitingForKey)
			StartCoroutine(AssignKey(keyName));
	}

	public void SendText(Text text)
	{
		buttonText = text;
	}

	IEnumerator WaitForKey()
	{
		while(!keyEvent.isKey)
		{
			yield return null;
		}
		//newKey = keyEvent.keyCode;
	}

	public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;

		yield return WaitForKey();

		switch(keyName)
		{
		case "up":
			for(int i = 0; i < GameManager.GM.keycodes.Count; i++)
			{
				if(GameManager.GM.keycodes[i] == newKey)
				{
					buttonText.text = "Key In Use";
					yield return new WaitForSeconds(1f);
					buttonText.text = GameManager.GM.up.ToString();
					yield break;
				}
			}
			GameManager.GM.up = newKey;
			GameManager.GM.UpdateKeyList();
			buttonText.text = GameManager.GM.up.ToString();
			PlayerPrefs.SetString("upKey", GameManager.GM.up.ToString());
			break;
		case "down":
			for(int i = 0; i < GameManager.GM.keycodes.Count; i++)
			{
				if(GameManager.GM.keycodes[i] == newKey)
				{
					buttonText.text = "Key In Use";
					yield return new WaitForSeconds(1f);
					buttonText.text = GameManager.GM.down.ToString();
					yield break;
				}
			}
			GameManager.GM.down = newKey;
			GameManager.GM.UpdateKeyList();
			buttonText.text = GameManager.GM.down.ToString();
			PlayerPrefs.SetString("downKey", GameManager.GM.down.ToString());
			break;
		case "jump":
			for(int i = 0; i < GameManager.GM.keycodes.Count; i++)
			{
				if(GameManager.GM.keycodes[i] == newKey)
				{
					buttonText.text = "Key In Use";
					yield return new WaitForSeconds(1f);
					buttonText.text = GameManager.GM.jump.ToString();
					yield break;
				}
			}
			GameManager.GM.jump = newKey;
			GameManager.GM.UpdateKeyList();
			buttonText.text = GameManager.GM.jump.ToString();
			PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString());
			break;
		case "sword":
			for(int i = 0; i < GameManager.GM.keycodes.Count; i++)
			{
				if(GameManager.GM.keycodes[i] == newKey)
				{
					buttonText.text = "Key In Use";
					yield return new WaitForSeconds(1f);
					buttonText.text = GameManager.GM.stab.ToString();
					yield break;
				}
			}
			GameManager.GM.stab = newKey;
			GameManager.GM.UpdateKeyList();
			buttonText.text = GameManager.GM.stab.ToString();
			PlayerPrefs.SetString("swordKey", GameManager.GM.stab.ToString());
			break;
		case "gun":
			for(int i = 0; i < GameManager.GM.keycodes.Count; i++)
			{
				if(GameManager.GM.keycodes[i] == newKey)
				{
					buttonText.text = "Key In Use";
					yield return new WaitForSeconds(1f);
					buttonText.text = GameManager.GM.shoot.ToString();
					yield break;
				}
			}
			GameManager.GM.shoot = newKey;
			GameManager.GM.UpdateKeyList();
			buttonText.text = GameManager.GM.shoot.ToString();
			PlayerPrefs.SetString("gunKey", GameManager.GM.shoot.ToString());
			break;
			//		default:
			//			yield return null;
			//			break;
		}

		yield return null;

	}

	///////////////////////////////

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
			if(keymapOpen)
				StartCoroutine(KeymapTimer2());
			else
			{
	            MaintargetScale.x = 0;
	            StartCoroutine(OptionsTimer());
			}
            
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

       options1Scale.y = 1f;
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

	IEnumerator KeymapTimer()
	{
		keymapOpen = true;
		yield return new WaitForSeconds(1f);
		keymapScale.y = 1f;

	}
		
	IEnumerator KeymapTimer2()
	{
		speed = 12;
		keymapOpen = false;
		keymapScale.y = 0f;
		yield return new WaitForSeconds(1f);
		speed = 8;
		options1Scale.y = 1;
		alreadyoptions = true;
	}
}
