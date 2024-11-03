using Netick.Unity;
using UnityEngine;
using NetworkPlayer = Netick.NetworkPlayer;

namespace StinkySteak.IM._3D.Gameplay
{
    public class Props3D : NetworkBehaviour
    {
        [SerializeField] private GameObject _renderer;
        [SerializeField] private bool _setInterestNarrow;

        public void SetInterestNarrow(bool setInterest)
        {
            _setInterestNarrow = setInterest;
        }

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