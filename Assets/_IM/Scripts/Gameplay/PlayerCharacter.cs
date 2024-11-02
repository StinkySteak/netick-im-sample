using Netick;
using Netick.Unity;
using StinkySteak.IM.Gameplay.Cam;
using StinkySteak.IM.PlayerInput;
using UnityEngine;

namespace StinkySteak.IM.Player
{
    public class PlayerCharacter : NetworkBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Transform _interpolationTarget;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Vector3 _interestSize;

        public override void NetworkStart()
        {
            if (IsInputSource)
            {
                CameraController camera = Sandbox.FindObjectOfType<CameraController>();
                camera.SetTarget(_interpolationTarget);
            }
        }

        public override void NetworkFixedUpdate()
        {
            if (FetchInput(out PlayerCharacterInput input))
            {
                Move(input);
                Rotate(input);
            }

            ProcessIM();
        }

        private void ProcessIM()
        {
            if (!IsServer) return;

            NetickBounds area = new(transform.position.ToNumerics(), _interestSize.ToNumerics());
            InputSource.AddInterestBoxArea(area);
        }

        private void Move(PlayerCharacterInput input)
        {
            Vector3 forward = input.Forward * transform.forward;
            Vector3 right = input.Right * transform.right;
            Vector3 up = input.Up * Vector3.up;

            Vector3 direction = forward + right + up;

            transform.position += direction.normalized * Sandbox.FixedDeltaTime * _moveSpeed;
        }

        private void Rotate(PlayerCharacterInput input)
        {
            Vector3 yaw = input.Yaw * Vector3.up * _rotateSpeed;
            transform.Rotate(yaw);
        }

        public override void OnBecameInterested()
        {
            _interpolationTarget.gameObject.SetActive(true);
        }

        public override void OnBecameUninterested()
        {
            _interpolationTarget.gameObject.SetActive(false);
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, _interestSize);
        }
    }
}