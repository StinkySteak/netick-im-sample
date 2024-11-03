using Netick;
using UnityEngine;

namespace StinkySteak.IM._2D.PlayerInput
{
    [Networked]
    public struct PlayerCharacter2DInput : INetworkInput
    {
        [Networked]
        public Vector2 Direction { get; set; }
    }
}