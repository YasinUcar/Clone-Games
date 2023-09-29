using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager.Animation
{
    public class AnimationManager : MonoBehaviour
    {
        public void ChangeAnimState(GameObject outgameObject, string animationName)
        {
            outgameObject.GetComponent<Animator>().SetTrigger(animationName);
        }
        public void ChangeAnimState(GameObject outgameObject, string animationName, bool boolState)
        {
            outgameObject.GetComponent<Animator>().SetBool(animationName, boolState);
        }
    }
}