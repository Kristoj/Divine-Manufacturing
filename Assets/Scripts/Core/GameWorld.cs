using UnityEngine;

public static class GameWorld {

    // Handles referencing to the local player
    private static Player pm_player;
    public static Player LocalPlayer {
        get {
            // If player reference is NULL print a error message
            if (pm_player == null) {
                Debug.LogError("CRITICAL ERROR: Couldn't find player reference!");
                return null;
            }
            return pm_player;
        }
        set {
            pm_player = value;
        }
    }

}
