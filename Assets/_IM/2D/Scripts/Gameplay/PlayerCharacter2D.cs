using Netick.Unity;
using StinkySteak.IM._2D.PlayerInput;
using StinkySteak.IM._2D.Gameplay.Cam;
using UnityEngine;

namespace StinkySteak.IM._2D.Gameplay.Match
{
    public class PlayerCharacter2D : NetworkBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private Vector3 _interestSize;
        [SerializeField] private Transform _interpolationTarget;

        public override void NetworkStart()
        {
            if (IsInputSource)
            {
                CameraController2D camera = Sandbox.FindObjectOfType<CameraController2D>();
                camera.SetTarget(_interpolationTarget);
            }
        }

        public override void NetworkFixedUpdate()
        {
            if (FetchInput(out PlayerCharacter2DInput input))
            {
                Vector3 velocity = input.Direction * Sandbox.FixedDeltaTime * _moveSpeed;

                transform.position += velocity;
            }

            ProcessIM();
        }

        private void ProcessIM()
        {
            if (!IsServer) return;

            Bounds area = new(transform.position, _interestSize);
            InputSource.AddInterestBoxArea(area);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, _interestSize);
        }
    }
}