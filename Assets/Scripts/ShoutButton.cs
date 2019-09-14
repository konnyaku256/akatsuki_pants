using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShoutButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;
    [SerializeField]
    private Image btn;

    private void Start()
    {
        btn = GetComponent<Image>();
    }
    // Start is called before the first frame update
    private float duration = 1.5f;
    void Update()
    {
        if (gm.IsEnableInput && Input.GetKey(KeyCode.Space))
        {       //durationの時間ごとに色が変わる
            float phi = Time.time / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
            btn.color = Color.HSVToRGB(amplitude, 1, 1);
        }
        else
        {
            btn.color = new Color(255, 255, 255);
        }
    }
}
