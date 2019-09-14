using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardButton : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log("PressStart!");
        gm.SetGameState(GameManager.GameState.Reward);
        SceneManager.LoadScene("Reward");
    }
}
