using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField]
    private Text tutorialText;
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private PaletteManager Palette;
    [SerializeField]
    private GameObject mainText;

    private string[] exampleText =
    {
        "まずはチュートリアルです！",
        "パンツの色を当てましょう！",
        "まずは「赤色」と叫んでください！",

    };

    // Start is called before the first frame update
    void Start()
    {
        tutorialText = GetComponent<Text>();
        tutorialText.text = exampleText[0];
        GameObject gameobj = GameObject.Find("GameManager");
        gm = gameobj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    private int count = 0;
    private bool neverDone = true;
    private bool neverDone1 = true;
    private float time = 0.0f;
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        if (count >= exampleText.Length-1 && neverDone)
        {
            time = 0.0f;
            gm.IsEnableInput = true;
            //gameObject.SetActive(false);
            tutorialText.fontStyle = FontStyle.Bold;
            neverDone = false;
            return;
        }
        if(gm.GetGameState() == GameManager.GameState.Main && neverDone1)
        {
            time = 0.0f;
            neverDone1 = false;
            
        }

        if (time >= 2.0f && count < exampleText.Length - 1)
        {
            count++;
            time = 0.0f;
            tutorialText.text = exampleText[count];
           
        }
        else if(time >= 2.0f && gm.GetGameState() == GameManager.GameState.Main)
        {
            time = 0.0f;
            Palette.ResetColor();
            gameObject.SetActive(false);
            Palette.transform.gameObject.SetActive(false);
            mainText.SetActive(true);
        }
    }
}
