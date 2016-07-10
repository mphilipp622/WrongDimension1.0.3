using UnityEngine;
using System.Collections;

public class alphaChanger : MonoBehaviour {


    Color baseColor;
    Color darkenedColor;
    Color highlightedColor;

    bool changeAlpha;
    bool changeHighlight;



    // Use this for initialization
    void Start () {
        baseColor = new Color(1, 1, 1, 1);
        darkenedColor = new Color(1, 1, 1, 0.4f);
        highlightedColor = new Color(1.3f, 1.3f, 1.3f, 1);

    }
	
	// Update is called once per frame
	void Update () {

        //if (changeAlpha)
        //    gameObject.GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f, 0.4f);

        //if (!changeAlpha)
        //    gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);


        

       

        //changeHighlight = false;
        //changeAlpha = false;
    }



    void OnTriggerStay(Collider col)
    {
        
        if (col.gameObject.tag == "AlphaChanger")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(baseColor, darkenedColor, 1 );
            // gameObject.GetComponent<Renderer>().material.color = new Color(1.5f, 1.5f, 1.5f, 0.4f);
            changeAlpha = true;
        }

        if (col.gameObject.name == "Highlighter")
        {
            //gameObject.GetComponent<Renderer>().material.color = new Color(1.3f, 1.3f, 1.3f, 1f);
            changeAlpha = false;
            changeHighlight = true;

            if (!changeAlpha)
                gameObject.GetComponent<Renderer>().material.color = new Color(1.3f, 1.3f, 1.3f, 1f);
        }

    }

    void OnTriggerExit(Collider col)
    {

        
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);

        if (!changeHighlight && !changeAlpha)
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);


    }
}
