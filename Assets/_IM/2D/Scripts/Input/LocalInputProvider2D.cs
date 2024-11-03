using Netick.Unity;
using UnityEngine;

namespace StinkySteak.IM._2D.PlayerInput
{
    public class LocalInputProvider2D : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            PlayerCharacter2DInput input = new();

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            input.Direction = new Vector2(x, y);

            sandbox.SetInput(input);
        }
    }
}