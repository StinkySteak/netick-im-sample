using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.PlayerInput
{
    public class LocalInputProvider : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            PlayerCharacterInput input = new();
            input.Right = (int)Input.GetAxisRaw("Horizontal");
            input.Forward = (int)Input.GetAxisRaw("Vertical");
            input.Up = (int)Input.GetAxisRaw("Flying");
            input.Yaw = (int)Input.GetAxisRaw("Yaw");

            sandbox.SetInput(input);
        }
    }
}