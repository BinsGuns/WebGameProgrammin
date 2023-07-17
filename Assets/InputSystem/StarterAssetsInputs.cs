using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif


	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		private bool isPause = false;

		public TextMeshProUGUI Score;
		private CustomInput _customInput;

		private void Awake()
		{
			_customInput = new CustomInput();
		}

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		// public void OnMove(InputValue value)
		// {
		// 	MoveInput(value.Get<Vector2>());
		// }

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		// public void OnJump(InputValue value)
		// {
		// 	JumpInput(value.isPressed);
		// }

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif
	
		private void OnEnable()
		{
			_customInput.Enable();
		}

		private void OnDisable()
		{
			_customInput.Disable();
		}

		private void Start()
		{
			_customInput.Player.Move.started += ctx => Move(ctx);
			_customInput.Player.Jump.started += ctx => Jump(ctx);
		}

		private void Jump(InputAction.CallbackContext ctx)
		{
			JumpInput(ctx.ReadValueAsButton());
		}

		private void Move(InputAction.CallbackContext ctx)
		{
			MoveInput(ctx.ReadValue<Vector2>());
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
		
		public void OnPauseGame ()
		{
			Debug.Log("P");
			isPause = true;
		}
		public void OnResumeGame ()
		{
			isPause = false;
		}
		
		
		public void OnQuitGame()
		{
			Debug.Log("SAVE");
			PlayerPrefs.SetString("PlayerScore", Score.text);
			SceneManager.LoadScene("MainMenu");

		}
		private void Update()
		{
			

			if (isPause)
			{
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
			}

		}
	}
	
