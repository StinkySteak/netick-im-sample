using Netick.Unity;
using UnityEngine;
using NetworkPlayer = Netick.NetworkPlayer;
using Netick;
using StinkySteak.IM._3D.Gameplay;

namespace StinkySteak.IM._2D.Gameplay
{
    public class Props2D : NetworkBehaviour
    {
        [SerializeField] private GameObject _visual;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private bool _setInterestNarrow;
        [Networked] private Color _color { get; set; }

        public void SetInterestNarrow(bool setInterest)
        {
            _setInterestNarrow = setInterest;
        }

        public void RandomizeColor()
        {
            _color = Random.ColorHSV();
        }


        [OnChanged(nameof(_color))]
        private void OnChangedColor(OnChangedData onChangedData)
        {
            _renderer.color = _color;
            Sandbox.Log($"[{nameof(Props3D)}]: Color randomized");
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
            _visual.SetActive(true);
        }

        public override void OnBecameUninterested()
        {
            _visual.SetActive(false);
        }
    }
}