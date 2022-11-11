using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

	[SerializeField]
	private Rigidbody2D _rigidbody = null;
	[SerializeField]
	private float _movingSpeed = 1f;
	[SerializeField]
	private float _jumpForce = 1f;

	private PlayerControl _controller = null;
	private void Start()
	{
		_controller = new PlayerControl();
		_controller.Player.Jump.performed += Jump;
		_controller.Player.Jump.Enable();
		_controller.Player.Move.Enable();
	}

	private void FixedUpdate()
	{
		Moving();
	}

	private void Moving()
	{
		_rigidbody.velocity = new Vector2(_controller.Player.Move.ReadValue<float>() * _movingSpeed, _rigidbody.velocity.y);
	}

	public void Jump(InputAction.CallbackContext context)
	{
		Debug.Log(context);
		if (context.performed)
		{
			_rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
		}
	}

}
