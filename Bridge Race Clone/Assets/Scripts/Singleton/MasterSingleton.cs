using Manager.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton Instance { get; private set; }
    public AnimationManager AnimationManager { get; private set; }
    private void Awake()
    {
        //Instance varsa ve bu instance ben de�ilsem
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this; //instance'� bu obje yap refi varm�� olduk
        AnimationManager = GetComponentInChildren<AnimationManager>();
    }
}
