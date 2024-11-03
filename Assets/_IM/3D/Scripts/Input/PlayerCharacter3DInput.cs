using Netick;
using UnityEngine;

namespace StinkySteak.IM._3D.PlayerInput
{
    [Networked]
    public struct PlayerCharacter3DInput : INetworkInput
    {
        public int Right;
        public int Forward;
        public int Up;

        [Networked]
        public float Yaw { get; set; }
    }
}
