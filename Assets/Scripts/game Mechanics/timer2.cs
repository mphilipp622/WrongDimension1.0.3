using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer2 : MonoBehaviour {

   
    public int timeGiven;
    public float timeDiv;
    public float curTime;
    public float timeUp;
    public float addTimeAmount;
    public float filAmount;
    private float startFill;
    AudioSource timerBeeper;
    GameObject mainCamera;

	// Use this for initialization
	void Start () {
        curTime = timeGiven;
        timeDiv = timeGiven / 10f;
        timeUp = 0;
        timerBeeper = gameObject.GetComponent<AudioSource>();
       
       
    }

    void Awake()
    {
      
        mainCamera = GameObject.FindWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
        

        if(curTime <= timeGiven/ 5)
        {
            if (!timerBeeper.isPlaying)
            timerBeeper.Play();
        }

        if (curTime >= timeGiven / 5)
        {
            if (timerBeeper.isPlaying)
                timerBeeper.Stop();
        }

        curTime -= Time.deltaTime % 60;
        timeUp += Time.deltaTime;
        if(timeUp >= timeDiv)
        {
             
            mainCamera.GetComponent<FxPro>().FarTintStrength += 0.10f;
            mainCamera.GetComponent<FxPro>().Init();
           
            timeUp = 0;
           
        }

       if (curTime <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);

        }

	
	}

    public void ArcherKilled()
    {
        curTime += timeGiven / 6;
        mainCamera.GetComponent<FxPro>().FarTintStrength -= 0.10f;
        mainCamera.GetComponent<FxPro>().Init();
    }

    public void BullKilled()
    {
        curTime += timeGiven / 2;
        mainCamera.GetComponent<FxPro>().FarTintStrength -= 0.025f;
        mainCamera.GetComponent<FxPro>().Init();
    }

    public void BomberKilled()
    {
        curTime += timeGiven / 6;
        mainCamera.GetComponent<FxPro>().FarTintStrength -= 0.10f;
        mainCamera.GetComponent<FxPro>().Init();
    }

    public void SSKilled()
    {
        curTime += timeGiven / 8;
        mainCamera.GetComponent<FxPro>().FarTintStrength -= 0.05f;
        mainCamera.GetComponent<FxPro>().Init();
    }
}
