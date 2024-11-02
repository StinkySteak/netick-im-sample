using Netick;

namespace StinkySteak.IM.PlayerInput
{
    public struct PlayerCharacterInput : INetworkInput
    {
        public float Right;
        public float Forward;
        public float Up;

        public float Yaw;
    }
}