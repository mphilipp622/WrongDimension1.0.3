using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Image timerBar;
    public int timeGiven;
    public float timeDiv;
    public float curTime;
    public float timeUp;


	// Use this for initialization
	void Start () {
        timeDiv = timeGiven / 20f;
        timeUp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timeUp += Time.deltaTime;
        if(timeUp >= timeDiv)
        {
            timerBar.fillAmount -= 0.037f;
            timeUp = 0;
        }

       if (timerBar.fillAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);

        }

	
	}
}
