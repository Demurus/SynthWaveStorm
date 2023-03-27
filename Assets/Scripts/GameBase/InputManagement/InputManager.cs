using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameBase.InputManagement
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        private Vector2 _move;
        private InputControls _controls;
        private bool _controlsEnabled;

        public Vector2 Move => _move;

        public void Init()
        {
            _controls = new InputControls();
            _controls.GamePlay.StartTheBall.started += HandleBallStart;
        }

        public void SwitchControls(bool on)
        {
            if (on) _controls.Enable();
            else _controls.Disable();
        }

        private void Update()
        {
            if (!_controlsEnabled) return;
            HandleMovement(_controls.GamePlay.MovePad);
        }

        private void HandleMovement(InputAction action)
        {
            Vector2 readValue = action.ReadValue<Vector2>();
            _move = readValue;
        }

        private void HandleBallStart(InputAction.CallbackContext obj)
        {
            // send event
            Debug.Log(obj.action.name);
        }

        public void Dispose()
        {
            _controls.GamePlay.StartTheBall.started -= HandleBallStart;
        }
    }
}