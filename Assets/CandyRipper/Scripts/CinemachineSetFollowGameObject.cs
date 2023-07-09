using CandyRipper.Scripts.PlayerScripts;
using Cinemachine;
using UnityEngine;

namespace CandyRipper.Scripts
{
    public class CinemachineSetFollowGameObject : MonoBehaviour
    {
        private CinemachineVirtualCamera _cinemachineVirtualCamera;

        private void Start()
        {
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            _cinemachineVirtualCamera.Follow = FindObjectOfType<Player>().transform;
        }
    }
}