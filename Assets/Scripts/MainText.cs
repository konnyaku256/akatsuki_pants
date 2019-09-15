using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainText : MonoBehaviour
{
    [SerializeField]
    private Text mainText;
    [SerializeField]
    private GameManager gm;

    private string[] exampleText =
    {
        "それでは本番です！",
        "全力で叫んでください！",
        "３",
        "２",
        "1",
        "スタート！",
        "パンツの色を叫べ‼"
    };

    // Start is called before the first frame update
    void Start()
    {
        mainText = GetComponent<Text>();
    }
    private int count = 0;
    private bool neverDone = true;
    private float time = 0.0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (count >= exampleText.Length - 2 && neverDone)
        {
            gm.IsEnableInput = true;
            neverDone = false;
            mainText.fontStyle = FontStyle.Bold;
            return;
        }
        if (count < exampleText.Length - 1 && time >= 2.0f && ((count >= 0 && count <2) || (count>5)))
        {
            count++;
            time = 0.0f;
            mainText.text = exampleText[count];

        }
        else if(count < exampleText.Length-1 && time >= 1.0f && (count >=2 && count < 6))
        {
            count++;
            time = 0.0f;
            mainText.text = exampleText[count];
        }
    }
}
