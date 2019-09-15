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
    // Update is called once per frame
    void Update()
    {
        if (count >= exampleText.Length - 1 && neverDone)
        {
            gm.IsEnableInput = true;
            neverDone = false;
            return;
        }
        if (count < exampleText.Length - 1 && Input.GetMouseButtonDown(0))
        {
            count++;
            mainText.text = exampleText[count];

        }
    }
}
