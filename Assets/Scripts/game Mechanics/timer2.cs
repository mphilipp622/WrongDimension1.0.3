using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer2 : MonoBehaviour {

    public Image timerBar;
    public int timeGiven;
    public float timeDiv;
    public float curTime;
    public float timeUp;
    public float addTimeAmount;
    public float filAmount;
    private float startFill;
    AudioSource timerBeeper;

	// Use this for initialization
	void Start () {
        timeDiv = timeGiven / 20f;
        timeUp = 0;
        filAmount = timerBar.fillAmount;
        timerBeeper = gameObject.GetComponent<AudioSource>();
        startFill = filAmount;
       
    }

    void Awake()
    {
        timerBar = GameObject.FindWithTag("Timer").GetComponent<Image>();
        Debug.Log(GameObject.FindWithTag("Timer").name);

    }
	
	// Update is called once per frame
	void Update () {
        timerBar.fillAmount = filAmount;

        if(filAmount <= startFill/ 8)
        {
            if (!timerBeeper.isPlaying)
            timerBeeper.Play();
        }

        timeUp += Time.deltaTime;
        if(timeUp >= timeDiv)
        {
             filAmount -= 0.10f;
            timeUp = 0;
           
        }

       if (timerBar.fillAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);

        }

	
	}
}
