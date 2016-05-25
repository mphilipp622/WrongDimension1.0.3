using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    Image uiImage; // Image Component script is attached to
    Canvas parentCanvas; // Canvas that parents the Image UI

    [SerializeField]
    Sprite[] images; // Pictures wwe want to use

    //[SerializeField]
    //string sceneToLoad;

    [SerializeField]
    [Tooltip("If true, user has to press a key to proceed to next image")]
    bool clickToProceed;

    [SerializeField]
    [Tooltip("Amount of time it takes to complete a fade in or a fade out")]
    float fadeTime;

    [SerializeField]
    [Tooltip("Amount of time you want image to be displayed before fading out")]
    float displayTime;

    [SerializeField]
    [Tooltip("Amount of time you want image to stay transparent before fading in. Also applies after the last image has faded, before scene change.")]
    float transparentTime;

    void Start()
    {
        parentCanvas = GetComponent<Canvas>();
        if (parentCanvas.worldCamera != Camera.main)
            parentCanvas.worldCamera = Camera.main;

        DontDestroyOnLoad(gameObject);

        uiImage = GetComponentInChildren<Image>();

        uiImage.sprite = images[0];

        StartCoroutine(CycleImages());
    }

    void Update()
    {
        /*
		 * If we want this to be used throughout the game for scene transitions
		 * we will want to put some kind of condition here
		 * pseudo code:
		 * if(GameManager.instance.levelComplete)
		 *     StartCoroutine(CycleImages());
		 */
    }

    IEnumerator CycleImages()
    {
        //uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, 0); // Only need this if we use this script for transitioning levels regularly

        if (!clickToProceed)
        {
            for (int i = 0; i < images.Length; i++)
            {
                uiImage.sprite = images[i];
                uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, 0); // Start image off transparent
                                                                                                 //uiImage.color = Color.black; //Start image off black

                yield return new WaitForSeconds(transparentTime);

                for (float alpha = 0; alpha < 1; alpha += Time.deltaTime / fadeTime)
                {
                    uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade from Transparent

                    //uiImage.color = new Color(uiImage.color.r + alpha, uiImage.color.b + alpha, uiImage.color.g + alpha, 1); //Fade from Black

                    yield return null;
                }

                yield return new WaitForSeconds(displayTime);

                for (float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
                {
                    uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade to transparent

                    //uiImage.color = new Color(uiImage.color.r - alpha, uiImage.color.b - alpha, uiImage.color.r - alpha, 1); //Fade to Black
                    yield return null;
                }

            }

            //uiImage.color = Color.black; // Set the image to solid black for fade in effect on scene

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene based on the build index.

            yield return new WaitForSeconds(transparentTime);

            //parentCanvas.worldCamera = Camera.main; // Set our canvas to the new scene's main camera

            /*for(float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
			{
				uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade out our image so we can see our game

				yield return null;
			}*/


            //uiImage.gameObject.SetActive(false); // Disable the Image since we no longer need it, assumingly.

            Destroy(gameObject); //destroy the canvas
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                uiImage.sprite = images[i];
                uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, 0); // Start image off transparent
                                                                                                 //uiImage.color = Color.black; //Start image off black

                yield return new WaitForSeconds(transparentTime);

                for (float alpha = 0; alpha < 1; alpha += Time.deltaTime / fadeTime)
                {
                    uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade from Transparent

                    //uiImage.color = new Color(uiImage.color.r + alpha, uiImage.color.b + alpha, uiImage.color.g + alpha, 1); //Fade from Black

                    yield return null;
                }

                yield return StartCoroutine(WaitForMouseClick());

                for (float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
                {
                    uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade to transparent

                    //uiImage.color = new Color(uiImage.color.r - alpha, uiImage.color.b - alpha, uiImage.color.r - alpha, 1); //Fade to Black

                    yield return null;
                }

            }

            //uiImage.color = Color.black; // Set the image to solid black for fade in effect on scene

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene based on the build index.

            yield return new WaitForSeconds(transparentTime);

            //parentCanvas.worldCamera = Camera.main; // Set our canvas to the new scene's main camera

            /*for(float alpha = 1; alpha > 0; alpha -= Time.deltaTime / fadeTime)
			{
				uiImage.color = new Color(uiImage.color.r, uiImage.color.b, uiImage.color.g, alpha); // Fade out our image so we can see our game

				yield return null;
			}*/


            //uiImage.gameObject.SetActive(false); // Disable the Image since we no longer need it, assumingly.

            Destroy(gameObject); //destroy the canvas
        }

    }

    IEnumerator WaitForMouseClick()
    {
        while (!Input.GetMouseButton(0))
            yield return null;
    }
}
