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

	private void Awake() {
		m_propID = Shader.PropertyToID("_MainTex");
	}

	// Update is called once per frame
	void Update()
    {

    }


	public void SetPants() {




	}

	private void SetPantsTexture(Texture pantsTexture) {

		m_material.SetTexture(m_propID, pantsTexture);

	}
	
}
