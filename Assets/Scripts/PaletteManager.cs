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
                white.color = new Color(white.color.r, white.color.g, white.color.b, 0);
                break;
            case GameManager.PantsColor.Black:
                black.color = new Color(black.color.r, black.color.g, black.color.b, 0);
                break;
            case GameManager.PantsColor.Pink:
                pink.color = new Color(pink.color.r, pink.color.g, pink.color.b, 0);
                break;
            case GameManager.PantsColor.Red:
                red.color = new Color(red.color.r, red.color.g, red.color.b, 0);
                break;
            case GameManager.PantsColor.Blue:
                blue.color = new Color(blue.color.r, blue.color.g, blue.color.b, 0);
                break;
            case GameManager.PantsColor.Green:
                green.color = new Color(green.color.r, green.color.g, green.color.b, 0);
                break;
            case GameManager.PantsColor.Purple:
                purple.color = new Color(purple.color.r, purple.color.g, purple.color.b, 0);
                break;
            case GameManager.PantsColor.Yellow:
                yellow.color = new Color(yellow.color.r, yellow.color.g, yellow.color.b, 0);
                break;

        }
    }

    public void ResetColor()
    {
        white.color = new Color(white.color.r, white.color.g, white.color.b, 255);
        black.color = new Color(black.color.r, black.color.g, black.color.b, 255);

        pink.color = new Color(pink.color.r, pink.color.g, pink.color.b, 255);

        red.color = new Color(red.color.r, red.color.g, red.color.b, 255);

        blue.color = new Color(blue.color.r, blue.color.g, blue.color.b, 255);

        green.color = new Color(green.color.r, green.color.g, green.color.b, 255);

        purple.color = new Color(purple.color.r, purple.color.g, purple.color.b, 255);

        yellow.color = new Color(yellow.color.r, yellow.color.g, yellow.color.b, 255);


    }
}
