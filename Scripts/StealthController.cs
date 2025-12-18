using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StealthController : MonoBehaviour
{
    /// <summary>
    /// نور عمومی دوبعدی که روشنایی کل صحنه را تنظیم می‌کند.
    /// </summary>
    public Light2D globalLight;

    /// <summary>
    /// شدت نور در حالت عادی
    /// </summary>
    public float normalIntensity = 1f;

    /// <summary>
    /// شدت نور هنگام فعال بودن حالت مخفی‌کاری
    /// </summary>
    public float stealthIntensity = 0.3f;

    /// <summary>
    /// ارجاع به کنترلر حالت بتمن برای بررسی وضعیت فعلی
    /// </summary>
    public BatmanStateController stateController;

    void Update()
    {
        if(stateController != null && stateController.currentState == BatmanStateController.BatmanState.Stealth)
        {
            // حالت مخفی‌کاری: نور کم می‌شود
            globalLight.intensity = stealthIntensity;
        }
        else
        {
            // حالت عادی یا هشدار: نور به شدت معمولی برمی‌گردد
            globalLight.intensity = normalIntensity;
        }
    }
}
