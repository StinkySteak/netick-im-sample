using Netick.Unity;
using UnityEngine;
using NetworkPlayer = Netick.NetworkPlayer;
using Netick;

namespace StinkySteak.IM._3D.Gameplay
{
    public class Props3D : NetworkBehaviour
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private bool _setInterestNarrow;
        [Networked] private Color _color { get; set; }

        public override void NetworkFixedUpdate()
        {
            if (!IsServer) return;

            if (!Object.NarrowPhaseFilter) return;

            foreach (NetworkPlayer client in Sandbox.ConnectedClients)
            {
                Object.SetNarrowphaseInterest(client, _setInterestNarrow);
            }
        }

        public void RandomizeColor()
        {
            _color = Random.ColorHSV();
        }

        [OnChanged(nameof(_color))]
        private void OnChangedColor(OnChangedData onChangedData)
        {
            _renderer.material.color = _color;
            Sandbox.Log($"[{nameof(Props3D)}]: Color randomized");
        }

        public void SetInterestNarrow(bool setInterest)
        {
            _setInterestNarrow = setInterest;
        }

        public override void OnBecameInterested()
        {
            _visual.SetActive(true);
        }

        public override void OnBecameUninterested()
        {
            _visual.SetActive(false);
        }
    }
}