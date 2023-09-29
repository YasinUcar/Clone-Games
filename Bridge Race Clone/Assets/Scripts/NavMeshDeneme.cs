using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class NavMeshDeneme : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    public GameObject target;
    void Start()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        Gonder();

    }
    public void Gonder()
    {

        _navMeshAgent.SetDestination(target.transform.position);

    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            _navMeshAgent.Stop();
        }
        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            _navMeshAgent.Resume();
            _navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
