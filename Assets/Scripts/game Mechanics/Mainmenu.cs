using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour {

   // public GameObject mainMenuPanel;
    Animator MainMenuAnim;

    public GameObject[] MainMenuSelect;
    public GameObject[] LevelSelects;
    
    public float speed = 2.0f;

    private Vector3 MaintargetScale;
    private Vector3 LevtargetScale;
    
    private Vector3 baseScale;
    private Vector3 LevbaseScale;
    private int currScale;

    private bool mainMenuGone = false;
    private bool levelSelecting = false;

    [Tooltip("Make true, play game. Stop game, then make false. Clears save data")]
    public bool resetLevels;
    public int levelsUnlocked;
    

    // Use this for initialization
    void Start () {
        // MainMenuAnim = mainMenuPanel.GetComponent<Animator>();
        baseScale = transform.localScale;
        MaintargetScale = baseScale;


        
        foreach (GameObject obj2 in LevelSelects)
        {
            LevbaseScale.x = 0.14f;
            LevtargetScale = obj2.transform.localScale;
            //obj2.transform.localScale = new Vector3(LevbaseScale.x, LevbaseScale.y, LevbaseScale.z);
        }

        if (resetLevels)
        {
			#if UNITY_WEBGL
	            PlayerPrefs.SetInt("HighestLevelUnlocked", 2);
	            levelsUnlocked= PlayerPrefs.GetInt("HighestLevelUnlocked");

			#else
				GameManager.GM.levelUnlocked = 2;
				levelsUnlocked = GameManager.GM.levelUnlocked;
				GameManager.GM.Save();

			#endif

            resetLevels = false;
        }

		#if UNITY_WEBGL
			levelsUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked");

		#else
			GameManager.GM.Load(); // Loads our saved level data
			levelsUnlocked = GameManager.GM.levelUnlocked;

		#endif

    }
	
	// Update is called once per frame
	void Update () {



        foreach (GameObject obj in MainMenuSelect)
            {
                MaintargetScale.y = 0.5f;
            
                obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, MaintargetScale, speed * Time.deltaTime);
                
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

    public void GameStart()
    {
        //MainMenuAnim.SetBool("PickingLevel", true);

        Debug.Log("Should be shrinking");
            MaintargetScale.x = 0;
        StartCoroutine(Timer());


    }

    public void GameExit()
    {
        Application.Quit();

    }

    //public void LoadLevel()
    //{

    //    Application.LoadLevel(2);
    //}

    //public void LoadLevel2()
    //{
    //    if (level2.GetComponent<LockedLevel>().canPlay)
    //    {
    //        Application.LoadLevel(3);
    //    }
    //}

    //public void LoadLevel3()
    //{
    //    if (level3.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(4);
    //}

    //public void LoadLevel4()
    //{
    //    if (level4.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(5);
    //}

    //public void LoadLevel5()
    //{
    //    if (level5.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(6);
    //}

    //public void LoadLevel6()
    //{
    //    if (level6.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(7);
    //}

    //public void LoadLevel7()
    //{
    //    if (level7.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(8);
    //}

    //public void LoadLevel8()
    //{
    //    if (level8.GetComponent<LockedLevel>().canPlay)
    //        Application.LoadLevel(9);
    //}



    IEnumerator Timer()
    {

        yield return new WaitForSeconds(0.75f);
        
        LevtargetScale.y = 1f;
        Debug.Log("Level Select");
    }
}
