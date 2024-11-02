using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.Gameplay.Match
{
    public class MatchManager : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _playerCharacterPrefab;
        [SerializeField] private NetworkObject _propsPrefab;
        [SerializeField] private int _propsCount;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private float _spawnRadiusUp;

        public override void NetworkStart()
        {
            if (!Sandbox.IsServer) return;

            Sandbox.Events.OnPlayerConnected += OnPlayerConnected;

            for (int i = 0; i < _propsCount; i++)
            {
                Vector3 position = Random.insideUnitSphere * _spawnRadius;
                position.y = Random.Range(-_spawnRadiusUp, _spawnRadiusUp);

                Sandbox.NetworkInstantiate(_propsPrefab, position, Quaternion.identity);
            }
        }

        private void OnPlayerConnected(NetworkSandbox sandbox, Netick.NetworkPlayer player)
        {
            sandbox.NetworkInstantiate(_playerCharacterPrefab, transform.position, Quaternion.identity, player);
        }
    }
}
