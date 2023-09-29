using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Event.Brick
{
    public class BrickEvent : MonoBehaviour
    {
        public static UnityAction CreateFirstBricks;
        public static UnityAction FirstDestinationEvent;
        public static UnityAction NextDestinationControllerEvent;
        public static UnityAction BridgeBrickEvent;

    }
}