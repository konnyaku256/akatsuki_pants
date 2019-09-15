using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Tutorial,
        Main,
        Result,
        Reward
    };

    public enum PantsColor
    {
        White,
        Black,
        Pink,
        Red,
        Blue,
        Green,
        Purple,
        Yellow
    };

    //デバック用キー
    [SerializeField]
    private KeyCode answerKey = KeyCode.A;

    [SerializeField]
    private PantsColor answerColor;

    //private PantsColor currentColor = PantsColor.None;

    [SerializeField]
    private PaletteManager Palette;

    [SerializeField]
    private GameObject mainText;
    [SerializeField]
    private GameObject tutorialText;
    [SerializeField]
    private AudioSource wrongSE;
    [SerializeField]
    private AudioSource correctSE;

    [SerializeField]
    private GameObject resultText;

    private IBM.Watsson.Examples.ExampleStreaming ExampleStreaming;

    private Dictionary<string, PantsColor> pants = new Dictionary<string, PantsColor>();
    private bool isPressedVoiceButton;

    private static bool Cleared = false;

    string[] colorKanji =
    {
        "白",
        "黒",
        "ピンク",
        "赤",
        "青",
        "緑",
        "紫",
        "黄",
    };

    public bool IsClear
    {
        get { return Cleared; }
        set { Cleared = value; }
    }

    [HideInInspector]
    private bool enableInput = false;

    public bool IsEnableInput
    {
        get { return enableInput; }
        set { enableInput = value; }
    }


    private static GameState currentState;

    private static int answerCount = 0;


    // Start is called before the first frame update
    void Start()
    {

        InitializePants();

        if (SceneManager.GetActiveScene().name == "Title")
        {
            SetGameState(GameState.Title);
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
            //correctSE = GetComponent<AudioSource>();
            //wrongSE = GetComponent<AudioSource>();
            Palette.transform.gameObject.SetActive(false);
            answerColor = PantsColor.Red;
            SetGameState(GameState.Tutorial);
        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {
            SetGameState(GameState.Result);
            resultText.GetComponent<Text>().text = "叫んだ回数　　" + answerCount + "回";
        }
        else if (SceneManager.GetActiveScene().name == "Reward")
        {
            SetGameState(GameState.Reward);
        }
    }

    // Update is called once per frame
    private bool neverDone = true;
    void Update()
    {
        
        if(IsEnableInput)
        {
            if(neverDone)
            {
                Palette.transform.gameObject.SetActive(true);
               // Debug.Log("aaaaaaaaaaaaa");
                neverDone = false;
            }
            isPressedVoiceButton = Input.GetKey(KeyCode.Space);

            //デバック用
            // DownKeyCheck();

        }
     //   Debug.Log(answerCount);
    }

    public GameState GetGameState()
    {
        return currentState;
    }

    public void SetGameState(GameState state)
    {
        currentState = state;
    }

    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (code == answerKey && Input.GetKeyDown(code))
                {
                    //答えがあったていた時の処理
                    //チュートリアルの場合は例外
                    if (GetGameState() == GameState.Tutorial)
                    {
                        Palette.RemoveColor(PantsColor.Red);
                        tutorialText.GetComponent<Text>().text = "正解!";
                        correctSE.Play();
                        SetGameState(GameState.Main);
                        IsEnableInput = false;
                        neverDone = true;
                        answerCount=0;

                    }
                    else if(GetGameState() == GameState.Main)
                    {
                        Palette.RemoveColor(PantsColor.Red);
                        IsEnableInput = false;
                        correctSE.Play();
                        answerCount++;
                        SetGameState(GameState.Result);
                        mainText.GetComponent<Text>().text = "正解！";
                    }
                    break;
                }
                else if (code != KeyCode.Space && Input.GetKeyDown(code))
                {
                    //間違っていた時の処理
                    Debug.Log("間違い");
                    wrongSE.Play();
                    answerCount++;
                    break;
                }
            }
        }
    }

    public void InputVoiceString(String voice)
    {

        if (!isPressedVoiceButton)
            return;

        Debug.Log(voice);
        var temp = GetContainColorKanji(voice);
        Debug.Log(temp);
        if (!pants.ContainsKey(temp))
            return;

        PantsColor voicePantsColor = pants[temp];

        Debug.Log(answerColor);

        if (answerColor == voicePantsColor)
        {
            if (GetGameState() == GameState.Tutorial)
            { 
                Palette.RemoveColor(voicePantsColor);
                tutorialText.GetComponent<Text>().text = "正解!";
                correctSE.Play();
                SetGameState(GameState.Main);
                IsEnableInput = false;
                neverDone = true;
                SetAnswerPantsColor();
                answerCount = 0;

            }
            else if (GetGameState() == GameState.Main)
            {
                Palette.RemoveColor(voicePantsColor);
                correctSE.Play();
                answerCount++;
                SetGameState(GameState.Result);
                mainText.GetComponent<Text>().text = "正解！";
            }
        }
        else
        {
            //間違っていた時の処理
            Debug.Log("間違い");
            wrongSE.Play();
            answerCount++;
        }

    }

    void InitializePants() {

        pants.Add("白", PantsColor.White);
        pants.Add("黒", PantsColor.Black);
        pants.Add("ピンク", PantsColor.Pink);
        pants.Add("赤", PantsColor.Red);
        pants.Add("青", PantsColor.Blue);
        pants.Add("緑", PantsColor.Green);
        pants.Add("紫", PantsColor.Purple);
        pants.Add("黃", PantsColor.Yellow);
    }

    void SetAnswerPantsColor() {

        var pantsValue = UnityEngine.Random.Range(0, Enum.GetNames(typeof(PantsColor)).Length);
        answerColor = (PantsColor)Enum.ToObject(typeof(PantsColor), pantsValue);

    }

    private string GetContainColorKanji(string voice)
    {
        foreach(var s in colorKanji)
        {
            if (voice.Contains(s))
                return s;

        }

        return voice;

    }

}
