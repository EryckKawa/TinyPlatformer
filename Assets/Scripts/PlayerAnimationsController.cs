using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{
	private string _IS_WALKING = "IsWalking";
	private Animator _animator;
	[SerializeField] private Player _player;
	// Start is called before the first frame update
	void Start()
	{
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		_animator.SetBool(_IS_WALKING, _player.IsWalking());
	}
}
