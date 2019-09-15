using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiAniamtorManager : MonoBehaviour
{

	[SerializeField]
	private int m_hintCount;

	[SerializeField]
	private float m_jump1Volume;
	[SerializeField]
	private float m_jump2Volume;
	[SerializeField]
	private float m_jump3Volume;

	private Animator m_animator;

	private int m_wrongCount;

	public Single Jump1Volume {
		get {
			return m_jump1Volume;
		}

		set {
			m_jump1Volume = value;
		}
	}

	// Start is called before the first frame update
	void Start()
    {

		m_animator = GetComponent<Animator>();

    }

	public void WrongAnswer() {

		m_wrongCount++;
		PlayRefuseAnimation();
		if (m_wrongCount < m_hintCount)
			return;





	}

	void PlayRefuseAnimation() {

		AnimatorStateInfo stateinfor = m_animator.GetCurrentAnimatorStateInfo(0);

		if (stateinfor.IsName("Refuse1") || stateinfor.IsName("Refuse2"))
			return;

		if (UnityEngine.Random.Range(0, 2) == 1)
			m_animator.SetTrigger("Refuse1");
		else
			m_animator.SetTrigger("Refuse2");

	}

	public void AoiJump(float voiceVolume) {

		if (voiceVolume > m_jump3Volume)
			m_animator.SetTrigger("Jump3");
		else if (voiceVolume > m_jump2Volume)
			m_animator.SetTrigger("Jump2");
		else if (voiceVolume > m_jump1Volume)
			m_animator.SetTrigger("Jump1");
	}

	public void AoiNodAnimation() {

		m_animator.SetTrigger("Nod");

	}

}
