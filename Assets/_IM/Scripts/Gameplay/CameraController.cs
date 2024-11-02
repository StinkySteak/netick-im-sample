using UnityEngine;

namespace StinkySteak.IM.Gameplay.Cam
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _rearOffset;
        [SerializeField] private float _upOffset;
        [SerializeField] private float _pitch;
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if (_target == null) return;

            Vector3 rearOffset = transform.forward * _rearOffset;
            Vector3 upoffset = Vector3.up * _upOffset;

            transform.position = _target.position - rearOffset + upoffset;


            Vector3 rotation = _target.rotation.eulerAngles;
            rotation.x = _pitch;

            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}