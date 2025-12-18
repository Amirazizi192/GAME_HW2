using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StealthController : MonoBehaviour
{
    public Light2D globalLight; // Global Light 2D
    public float normalIntensity = 1f;
    public float stealthIntensity = 0.3f;

    public BatmanStateController stateController;

    void Update()
    {
        if(stateController.currentState == BatmanStateController.BatmanState.Stealth)
        {
            globalLight.intensity = stealthIntensity;
        }
        else
        {
            globalLight.intensity = normalIntensity;
        }
    }
}
