using Netick.Unity;
using UnityEngine;
using NetworkPlayer = Netick.NetworkPlayer;

namespace StinkySteak.IM.Gameplay
{
    public class Props : NetworkBehaviour
    {
        [SerializeField] private GameObject _renderer;
        [SerializeField] private bool _setInterestNarrow;

        public override void NetworkFixedUpdate()
        {
            if (!IsServer) return;

            foreach (NetworkPlayer client in Sandbox.ConnectedClients)
            {
                Object.SetNarrowphaseInterest(client, _setInterestNarrow);
            }
        }

        public override void OnBecameInterested()
        {
            _renderer.SetActive(true);
        }

        public override void OnBecameUninterested()
        {
            _renderer.SetActive(false);
        }
    }
}