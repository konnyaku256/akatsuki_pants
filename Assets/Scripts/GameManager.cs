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
        Grren,
        Purple,
        Yellow
    };

    //デバック用キー
    [SerializeField]
    private KeyCode answerKey = KeyCode.A;

    [SerializeField]
    private GameObject mainText;

    [SerializeField]
    private GameObject resultText;

    private static bool Cleared = false;
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
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SetGameState(GameState.Title);
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
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
    void Update()
    {
        
        if(IsEnableInput)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                //デバック用
                DownKeyCheck();
            }
        }
        Debug.Log(answerCount);
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
                        
                        mainText.SetActive(true);
                        SetGameState(GameState.Main);
                        IsEnableInput = false;
                        answerCount=0;

                    }
                    else if(GetGameState() == GameState.Main)
                    {
                        IsEnableInput = false;
                        answerCount++;
                        SetGameState(GameState.Result);
                        SceneManager.LoadScene("Result");
                    }
                    break;
                }
                else if (Input.GetKeyDown(code))
                {
                    //間違っていた時の処理
                    Debug.Log("間違い");
                    answerCount++;
                    break;
                }
            }
        }
    }
}
