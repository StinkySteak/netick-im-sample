using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM.PlayerInput
{
    public class LocalInputProvider : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            PlayerCharacterInput input = new();
            input.Right = Input.GetAxisRaw("Horizontal");
            input.Forward = Input.GetAxisRaw("Vertical");
            input.Up = Input.GetAxisRaw("Flying");
            input.Yaw = Input.GetAxisRaw("Yaw");

            sandbox.SetInput(input);
        }
    }
}