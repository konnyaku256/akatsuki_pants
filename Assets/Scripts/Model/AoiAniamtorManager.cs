using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoiAniamtorManager : MonoBehaviour
{

	[SerializeField]
	private int m_hintCount;

	private Animator m_animator;

	private int m_wrongCount;

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

		m_animator.SetTrigger("Hint");



	}

	void PlayRefuseAnimation() {

		AnimatorStateInfo stateinfor = m_animator.GetCurrentAnimatorStateInfo(0);

		if (stateinfor.IsName("Refuse1") || stateinfor.IsName("Refuse2"))
			return;

		if (Random.Range(0, 2) == 1)
			m_animator.SetTrigger("Refuse1");
		else
			m_animator.SetTrigger("Refuse2");

	}

}
