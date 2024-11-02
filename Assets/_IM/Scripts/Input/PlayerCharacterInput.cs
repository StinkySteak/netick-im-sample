using Netick;

namespace StinkySteak.IM.PlayerInput
{
    [Networked]
    public struct PlayerCharacterInput : INetworkInput
    {
        public int Right;
        public int Forward;
        public int Up;

        [Networked]
        public float Yaw { get; set; }
    }
}