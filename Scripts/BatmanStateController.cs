using UnityEngine;

public class BatmanStateController : MonoBehaviour
{
    /// <summary>
    /// ارجاع به کنترلر حالت هشدار برای روشن یا خاموش کردن نورها و صدا
    /// </summary>
    public AlertController alertController; 

    /// <summary>
    /// تعریف حالت‌های مختلف بتمن
    /// Normal: حالت عادی
    /// Stealth: حالت مخفی‌کاری (حرکت آهسته و تاریکی نسبی)
    /// Alert: حالت هشدار (نور و صدا فعال)
    /// </summary>
    public enum BatmanState
    {
        Normal,
        Stealth,
        Alert
    }

    /// <summary>
    /// حالت فعلی بتمن
    /// </summary>
    public BatmanState currentState = BatmanState.Normal;

    void Update()
    {
        HandleStateInput();
    }

    /// <summary>
    /// بررسی ورودی‌های کاربر برای تغییر حالت بتمن
    /// C → حالت مخفی‌کاری
    /// Space → حالت هشدار
    /// N → حالت عادی
    /// </summary>
    void HandleStateInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SetState(BatmanState.Stealth);

        if (Input.GetKeyDown(KeyCode.Space))
            SetState(BatmanState.Alert);

        if (Input.GetKeyDown(KeyCode.N))
            SetState(BatmanState.Normal);    
    }

    /// <summary>
    /// تغییر حالت بتمن و اعمال اثرات مرتبط
    /// </summary>
    void SetState(BatmanState newState)
    {
        currentState = newState;

        // فعال یا غیرفعال کردن کنترلر هشدار بر اساس حالت
        if (alertController != null)
            alertController.SetAlert(currentState == BatmanState.Alert);

        switch (currentState)
        {
            case BatmanState.Normal:
                break;

            case BatmanState.Stealth:
                break;

            case BatmanState.Alert:
                break;
        }
    }
}
