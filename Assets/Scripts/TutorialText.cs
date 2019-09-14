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

    private string[] exampleText =
    {
        "パンツの色を当てましょう",
        "赤色と叫んでください"
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
    void Update()
    {
        if (gm.GetGameState() == GameManager.GameState.Main)
        {
            gameObject.SetActive(false);
        }
        if (count >= exampleText.Length-1 && neverDone)
        { 
            gm.IsEnableInput = true;
            neverDone = false;
            return;
        }

        if (Input.GetMouseButtonDown(0) && count < exampleText.Length - 1)
        {
            count++;
            tutorialText.text = exampleText[count];
           
        }
    }
}
