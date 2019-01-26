using UnityEngine;
using UnityEngine.UI;

namespace Dima.DebugStuff {

    public class DebugUI : MonoBehaviour {

        public Text focusRoundText;
        public Text focusRawText;
        public Text focusGreatestText;
        public Text playerVelocityText;

        void Update() {
            UpdateUI();
        }

        void UpdateUI() {
            if (focusRoundText != null)
                focusRoundText.text = "Tile rounded: " + GameWorld.LocalPlayer.Player_Building.GetHitPosition().ToString("F1");
            if (focusRawText != null)
                focusRawText.text = "Tile Raw: " + GameWorld.LocalPlayer.Player_Building.GetRaycastInfo().point.ToString("F2");
            if (focusGreatestText != null)
                focusGreatestText.text = "Greatest: " + GameWorld.LocalPlayer.Player_Building.GreatestAxis;
            if (playerVelocityText != null) {
                playerVelocityText.text = "Pvel: " + GameWorld.LocalPlayer.Player_Controller.velocity.ToString("F1");
            }

        }

    }

}