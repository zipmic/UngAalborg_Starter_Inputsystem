using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private Rigidbody _rb;
	private PlayerInput _playerInput;
	private PlayerInputActions _playerInputActions;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_playerInputActions = new PlayerInputActions();
		_playerInputActions.Player.Enable();
		_playerInputActions.Player.Jump.performed += Jump;
	

	}

	private void Update()
	{
		Vector2 inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
		float speed = 5f;
		_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
	}

	public void Jump(InputAction.CallbackContext context)
    {
        //print("Jump!" + context.phase);
		if (context.performed)
		{
			_rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
		}
    }

	public void Movement(InputAction.CallbackContext context)
	{
		Vector2 inputVector = context.ReadValue<Vector2>();
		float speed = 5f;
		_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
	}
}
