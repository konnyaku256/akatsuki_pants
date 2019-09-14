using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimatorSelecter : MonoBehaviour
{

	[SerializeField]
	private List<RuntimeAnimatorController> m_AnimatorController;

	private Animator m_animator;

	private void Awake() {

		InitializeAnimator();

	}

	private void Start() {

	}

	void InitializeAnimator() {

		m_animator = GetComponent<Animator>();
		m_animator.runtimeAnimatorController = m_AnimatorController[Random.Range(0, m_AnimatorController.Count)];

	}

}
