using UnityEngine;

[System.Serializable]
public class SettingsData
{
    #region Keybinds
    public KeyCode ForwardKey = KeyCode.W;
    public KeyCode BackwardKey = KeyCode.S;
    public KeyCode StrafeLeftKey = KeyCode.A;
    public KeyCode StrafeRightKey = KeyCode.D;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;
    #endregion

    #region Values
    public float WalkSpeed = 3f;
    public float RunSpeed = 8f;
    #endregion
}
