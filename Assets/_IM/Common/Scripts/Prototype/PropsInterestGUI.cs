using Netick.Unity;
using StinkySteak.IM._2D.Gameplay;
using StinkySteak.IM._3D.Gameplay;
using System.Collections.Generic;
using UnityEngine;
using Network = Netick.Unity.Network;

namespace StinkySteak.IM.Prototype.UI
{
    public class PropsInterestGUI : NetworkEventsListener
    {
        private List<Props3D> _props3DBuffer = new(128);
        private List<Props2D> _props2DBuffer = new(128);

        private void OnGUI()
        {
            if (!Network.IsRunning) return;

            if (Sandbox == null) return;

            if (!Sandbox.IsServer) return;

            float buttonWidth = 200;
            float buttonHeight = 50;
            float offset = 10;

            Vector2 positionA = new Vector2(Screen.width - (buttonWidth + offset), Screen.height - ((buttonHeight * 1) + (offset * 1)));
            Vector2 positionB = new Vector2(Screen.width - (buttonWidth + offset), Screen.height - ((buttonHeight * 2) + (offset * 2)));
            Vector2 positionC = new Vector2(Screen.width - (buttonWidth + offset), Screen.height - ((buttonHeight * 3) + (offset * 3)));
            Vector2 size = new Vector2(buttonWidth, buttonHeight);

            if (GUI.Button(new Rect(positionA, size), "Set Interest to All"))
            {
                SetInterestNarrowAll(true);
            }

            if (GUI.Button(new Rect(positionB, size), "Set Interest to None"))
            {
                SetInterestNarrowAll(false);
            }

            if (GUI.Button(new Rect(positionC, size), "Random Props Color"))
            {
                ChangePropsColorToRandomAll();
            }
        }

        private void ScanProps()
        {
            _props3DBuffer = Sandbox.FindObjectsOfType<Props3D>();
            _props2DBuffer = Sandbox.FindObjectsOfType<Props2D>();
        }

        private void SetInterestNarrowAll(bool setInterest)
        {
            ScanProps();

            foreach (Props3D p in _props3DBuffer)
                p.SetInterestNarrow(setInterest);

            foreach (Props2D p in _props2DBuffer)
                p.SetInterestNarrow(setInterest);
        }

        private void ChangePropsColorToRandomAll()
        {
            ScanProps();

            foreach (Props3D p in _props3DBuffer)
                p.RandomizeColor();

            foreach (Props2D p in _props2DBuffer)
                p.RandomizeColor();
        }
    }
}