using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiCloth : MonoBehaviour
{

	[SerializeField]
	private Material m_material;

	private int m_propID;

	[SerializeField]
	private Texture m_white;
	[SerializeField]
	private Texture m_black;
	[SerializeField]
	private Texture m_pink;
	[SerializeField]
	private Texture m_red;
	[SerializeField]
	private Texture m_blue;
	[SerializeField]
	private Texture m_green;
	[SerializeField]
	private Texture m_purple;
	[SerializeField]
	private Texture m_yellow;

	private Dictionary<GameManager.PantsColor, Texture> m_pants = new Dictionary<GameManager.PantsColor, Texture>();

	private void Awake() {
		InitializePants();
		m_propID = Shader.PropertyToID("_MainTex");
	}

	// Update is called once per frame
	void Update()
    {

		if (Input.GetKeyDown(KeyCode.W))
			SetPants(GameManager.PantsColor.White);
		else if (Input.GetKeyDown(KeyCode.B))
			SetPants(GameManager.PantsColor.Black);
		else if (Input.GetKeyDown(KeyCode.P))
			SetPants(GameManager.PantsColor.Purple);
		else if (Input.GetKeyDown(KeyCode.Q))
			SetPants(GameManager.PantsColor.Pink);


    }


	public void SetPants(GameManager.PantsColor pantsColor) {

		SetPantsTexture(m_pants[pantsColor]);

	}

	private void SetPantsTexture(Texture pantsTexture) {

		m_material.SetTexture(m_propID, pantsTexture);

	}

	private void InitializePants() {

		m_pants.Add(GameManager.PantsColor.White, m_white);
		m_pants.Add(GameManager.PantsColor.Black, m_black);
		m_pants.Add(GameManager.PantsColor.Pink, m_pink);
		m_pants.Add(GameManager.PantsColor.Red, m_red);
		m_pants.Add(GameManager.PantsColor.Blue, m_blue);
		m_pants.Add(GameManager.PantsColor.Grren, m_green);
		m_pants.Add(GameManager.PantsColor.Purple, m_purple);
		m_pants.Add(GameManager.PantsColor.Yellow, m_yellow);


	}

}
