using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM._3D.PlayerInput
{
    public class LocalInputProvider3D : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            PlayerCharacter3DInput input = new();
            input.Right = (int)Input.GetAxisRaw("Horizontal");
            input.Forward = (int)Input.GetAxisRaw("Vertical");
            input.Up = (int)Input.GetAxisRaw("Flying");
            input.Yaw = (int)Input.GetAxisRaw("Yaw");

            sandbox.SetInput(input);
        }
    }
}