using UnityEngine;

namespace StinkySteak.IM._2D.Gameplay.Cam
{
    public class CameraController2D : MonoBehaviour
    {
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if (_target == null) return;

            transform.position = _target.transform.position;
        }
    }
}