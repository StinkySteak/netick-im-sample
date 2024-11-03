using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.Gameplay.Match
{
    public class MatchManager2D : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _playerCharacterPrefab;
        [SerializeField] private NetworkObject _propsPrefab;

        [Space]
        [SerializeField] private int _propsCount;
        [SerializeField] private float _spawnRadius;

        public override void NetworkStart()
        {
            if (!Sandbox.IsServer) return;

            Sandbox.Events.OnPlayerConnected += OnPlayerConnected;

            for (int i = 0; i < _propsCount; i++)
            {
                Vector3 position = Random.insideUnitCircle * _spawnRadius;

                Sandbox.NetworkInstantiate(_propsPrefab, position, Quaternion.identity);
            }
        }

        private void OnPlayerConnected(NetworkSandbox sandbox, Netick.NetworkPlayer player)
        {
            sandbox.NetworkInstantiate(_playerCharacterPrefab, transform.position, Quaternion.identity, player);
        }
    }
}
