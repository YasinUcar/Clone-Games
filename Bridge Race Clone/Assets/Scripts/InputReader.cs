using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Manager.Input
{

    public class InputReader : MonoBehaviour
    {
        public event UnityAction<Vector2> MoveEvent = delegate { };
        

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent.Invoke(context.ReadValue<Vector2>());
        }
    }
}