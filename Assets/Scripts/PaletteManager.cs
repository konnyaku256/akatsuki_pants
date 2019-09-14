using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteManager : MonoBehaviour
{
    [SerializeField]
    private Image white;
    [SerializeField]
    private Image black;
    [SerializeField]
    private Image pink;
    [SerializeField]
    private Image red;
    [SerializeField]
    private Image blue;
    [SerializeField]
    private Image green;
    [SerializeField]
    private Image purple;
    [SerializeField]
    private Image yellow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveColor(GameManager.PantsColor c)
    {
       switch(c)
        {
            case GameManager.PantsColor.White:
                white.color = new Color(0,0,0,0);
                break;
            case GameManager.PantsColor.Black:
                black.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Pink:
                pink.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Red:
                red.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Blue:
                blue.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Green:
                green.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Purple:
                purple.color = new Color(0, 0, 0, 0);
                break;
            case GameManager.PantsColor.Yellow:
                yellow.color = new Color(0, 0, 0, 0);
                break;

        }
    }

    public void ResetColor()
    {
        white.color = new Color(0, 0, 0, 0);
        black.color = new Color(0, 0, 0, 0);
        pink.color = new Color(0, 0, 0, 0);
        red.color = new Color(0, 0, 0, 0);
        blue.color = new Color(0, 0, 0, 0);
        green.color = new Color(0, 0, 0, 0);
        purple.color = new Color(0, 0, 0, 0);
        yellow.color = new Color(0, 0, 0, 0);


    }
}
