using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.Gameplay
{
    public class Props : NetworkBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;

        public override void OnBecameInterested()
        {
            _renderer.SetEnabled(Sandbox, true);
        }

        public override void OnBecameUninterested()
        {
            _renderer.SetEnabled(Sandbox, false);
        }
    }
}