using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    public void OnClick()
    {
        Debug.Log("PressStart!");
        gm.SetGameState(GameManager.GameState.Tutorial);
        SceneManager.LoadScene("Main1");
    }
}
