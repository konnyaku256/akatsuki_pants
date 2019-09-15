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
        Yellow,
        Pants
    };

    //デバック用キー
    [SerializeField]
    private KeyCode answerKey = KeyCode.A;

    [SerializeField]
    private static PantsColor answerColor;

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

    public static float voiceScore = 0.0f;
    [SerializeField]
    private GameObject resultText;
    [SerializeField]
    private Image antenImg;

    [SerializeField]
    private AoiCloth AoiCloth;

	[SerializeField]
	private AoiAniamtorManager AoiAniamtor;

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
        "パンツ",
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
        else if (SceneManager.GetActiveScene().name == "Main1")
        {
            //correctSE = GetComponent<AudioSource>();
            //wrongSE = GetComponent<AudioSource>();
            Palette.transform.gameObject.SetActive(false);
            answerColor = PantsColor.Red;
            AoiCloth.SetPants(answerColor);
            SetGameState(GameState.Tutorial);
        }
        else if (SceneManager.GetActiveScene().name == "Result")
        {
            SetGameState(GameState.Result);
            resultText.GetComponent<Text>().text = "叫んだ回数　　" + answerCount + "回\n" + "勇気  　"+ voiceScore*1000 ;
        }
        else if (SceneManager.GetActiveScene().name == "Reward")
        {
            AoiCloth.SetPants(answerColor);
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

    public void InputVoiceString(String voice, float voiceLevel)
    {

        if (!IsEnableInput)
            return;
        
        Debug.Log(voice);
        var temp = GetContainColorKanji(voice);
        Debug.Log(temp);

        Debug.Log(pants.ContainsKey(temp));
        if (!pants.ContainsKey(temp))
            return;

        if (pants[temp] == PantsColor.Pants)
        {
            Debug.Log("パンツ！");
            AoiAniamtor.AoiJump(voiceLevel);
            return;
        }

        PantsColor voicePantsColor = pants[temp];

        Debug.Log(answerColor);

        if (answerColor == voicePantsColor)
        {
            AoiAniamtor.AoiNodAnimation();
            if (GetGameState() == GameState.Tutorial)
            { 
                Palette.RemoveColor(voicePantsColor);
                tutorialText.GetComponent<Text>().text = "正解!";
                correctSE.Play();
                SetGameState(GameState.Main);
                //voiceScore = voiceLevel;
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
                voiceScore = voiceLevel;
                SetGameState(GameState.Result);
                mainText.GetComponent<Text>().text = "正解！";

                StartCoroutine(Anten());
            }
        }
        else
        {
            //間違っていた時の処理
            Palette.RemoveColor(voicePantsColor);
            Debug.Log("間違い");
            wrongSE.Play();
			AoiAniamtor.WrongAnswer();
            answerCount++;
        }

    }

    void InitializePants() {

        pants.Add("白", PantsColor.White);
        pants.Add("私", PantsColor.White);
        pants.Add("知る", PantsColor.White);
        pants.Add("知らん", PantsColor.White);

        pants.Add("黒", PantsColor.Black);
        pants.Add("から", PantsColor.Black);
        pants.Add("クローン", PantsColor.Black);
        pants.Add("グラン", PantsColor.Black);
        pants.Add("来る", PantsColor.Black);

        pants.Add("ピンク", PantsColor.Pink);
        pants.Add("ピーク", PantsColor.Pink);
        pants.Add("原型", PantsColor.Pink);
        pants.Add("元気", PantsColor.Pink);
        pants.Add("天気", PantsColor.Pink);
        pants.Add("連携", PantsColor.Pink);

        pants.Add("赤", PantsColor.Red);
        pants.Add("あかん", PantsColor.Red);
        pants.Add("バカ", PantsColor.Red);
        pants.Add("頭", PantsColor.Red);
        pants.Add("他", PantsColor.Red);
        pants.Add("アバター", PantsColor.Red);
        pants.Add("あと", PantsColor.Red);

        pants.Add("青", PantsColor.Blue);
        pants.Add("D_ア", PantsColor.Blue);
        pants.Add("あう", PantsColor.Blue);

        pants.Add("緑", PantsColor.Green);
        pants.Add("皆", PantsColor.Green);
        pants.Add("実", PantsColor.Green);
        pants.Add("未来", PantsColor.Green);
        pants.Add("メドレー", PantsColor.Green);
        
        pants.Add("紫", PantsColor.Purple);
        pants.Add("皆さん", PantsColor.Green);

        pants.Add("黄", PantsColor.Yellow);
        pants.Add("金", PantsColor.Yellow);
        pants.Add("経路", PantsColor.Yellow);
        
        pants.Add("パンツ", PantsColor.Pants);
    }

    void SetAnswerPantsColor() {

        var pantsValue = UnityEngine.Random.Range(0, Enum.GetNames(typeof(PantsColor)).Length);
        answerColor = (PantsColor)Enum.ToObject(typeof(PantsColor), pantsValue);
        AoiCloth.SetPants(answerColor);

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

    private IEnumerator Anten()
    {
        float time = 0;
        float alfa = 0;
        yield return  new WaitForSeconds(3.0f);

        while(time < 2.0f)
        {
            time += Time.deltaTime; 
            alfa += Time.deltaTime*0.5f;
            Debug.Log(alfa);
            antenImg.color = new Color(antenImg.color.r, antenImg.color.g, antenImg.color.b, alfa);

            yield return null;
        }
        SceneManager.LoadScene("Result");
        yield break;
    }

}
