using Event.Brick;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Android;

namespace AI.Controller
{
    public class AIDestinationController : MonoBehaviour
    {
        [SerializeField] CharactersData _charactersData;
        private BridgeData _currentData;
        private NavMeshAgent _navMeshAgent;
        private Transform _nextBrickTransform;
        public bool _isGoingToTheBridge;
        private int _targetValue = 0;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            //   BrickEvent.NextBrick += StartDestination;
            StartCoroutine(RandomTargetValue());
            _isGoingToTheBridge = false;
        }
        public void DestinationObject(BridgeData data)
        {
            _currentData = data;
            StartCoroutine(StartDestination());
        }
        public void DestinationObject(Transform brickTarget)
        {
            _nextBrickTransform = brickTarget;
            StartCoroutine(StartDestination());
        }

        IEnumerator StartDestination()
        {
            //TODO : Buradaki total degerler ve icerideki degerler otamatik olarak hesaplanabilir mi **matematiksel + IEnumarator'e ihtiyac duyulmayan bir senaryo uretilebilir mi?

            yield return new WaitForSeconds(1f);
            int totalDifference = _currentData.TotalDifferenceTarget;
            if (_targetValue == _charactersData.BrickCount)
            {
                _navMeshAgent.SetDestination(_currentData.BridgeLastLocation.position);
                _isGoingToTheBridge = true;
                print("Köprüye gidiyorum");
            }

            else if (_isGoingToTheBridge == false)
            {
                _navMeshAgent.Resume();
                if (totalDifference == _currentData.TotalCount) //0 = 0
                {
                    _navMeshAgent.SetDestination(_nextBrickTransform.transform.position);
                    print("Brick toplamaya gidiyorum");
                }
                else
                {
                    _navMeshAgent.SetDestination(_nextBrickTransform.transform.position);
                    print("Brick toplamaya gidiyorum");
                }
            }
        }
        public void StopDestination()
        {
            _navMeshAgent.Stop();
            BrickEvent.BridgeBrickEvent?.Invoke();
            _isGoingToTheBridge = false;
        }
        
        IEnumerator RandomTargetValue()
        {
            yield return new WaitForSeconds(1f);
            _targetValue = Random.Range(_currentData.TotalCount + 1, _currentData.TotalCount + 4);
        }
        private void OnDestroy()
        {

        }
    }

}
