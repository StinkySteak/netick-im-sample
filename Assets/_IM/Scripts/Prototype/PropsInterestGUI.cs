using Netick.Unity;
using StinkySteak.IM.Gameplay;
using System.Collections.Generic;
using UnityEngine;
using Network = Netick.Unity.Network;

namespace StinkySteak.IM.Prototype.UI
{
    public class PropsInterestGUI : NetworkEventsListener
    {
        private List<Props> _propsBuffer = new(128);

        private void OnGUI()
        {
            if (!Network.IsRunning) return;

            if (Sandbox == null) return;

            if (!Sandbox.IsServer) return;

            float buttonWidth = 200;
            float buttonHeight = 50;
            float offset = 10;

            Vector2 positionA = new Vector2(Screen.width - (buttonWidth + offset), Screen.height - (buttonHeight + offset));
            Vector2 positionB = new Vector2(Screen.width - (buttonWidth + offset), Screen.height - ((buttonHeight * 2) + (offset * 2)));
            Vector2 size = new Vector2(buttonWidth, buttonHeight);

            if (GUI.Button(new Rect(positionA, size), "Set Interest to All"))
            {
                _propsBuffer = Sandbox.FindObjectsOfType<Props>();

                foreach (Props p in _propsBuffer)
                {
                    p.SetInterestNarrow(true);
                }
            }

            if (GUI.Button(new Rect(positionB, size), "Set Interest to None"))
            {
                _propsBuffer = Sandbox.FindObjectsOfType<Props>();

                foreach (Props p in _propsBuffer)
                {
                    p.SetInterestNarrow(false);
                }
            }
        }
    }
}