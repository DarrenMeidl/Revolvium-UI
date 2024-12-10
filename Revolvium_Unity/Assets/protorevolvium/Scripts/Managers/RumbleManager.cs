//using Unity.VisualScripting;
using UnityEngine.InputSystem;
using GD;
public class RumbleManager : Singleton<RumbleManager>
{
    public void Rumble(float low, float high, float time)
    {
        if (Gamepad.current != null) // Check if any gamepad is connected
        {
            Gamepad.current.SetMotorSpeeds(low, high); 
            Invoke(nameof(StopRumble), time);
        }
    }
    public void StopRumble()
    {
        Gamepad.current?.ResetHaptics();
    }
}
