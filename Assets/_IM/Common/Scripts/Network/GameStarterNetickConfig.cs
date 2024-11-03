using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.Setup
{
    public class GameStarterNetickConfig : MonoBehaviour
    {
        [SerializeField] private PhysicsType _physicsType;
        [SerializeField] private Vector3 _worldSize;
        [SerializeField] private int _cellSize;

        private void Start()
        {
            NetickConfig config = Resources.Load<NetickConfig>(nameof(NetickConfig));
            config.PhysicsType = _physicsType;
            config.CellSize = _cellSize;
            config.WorldSize = _worldSize;
        }
    }
}