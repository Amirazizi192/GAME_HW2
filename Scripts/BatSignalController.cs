using UnityEngine;

public class BatSignalController : MonoBehaviour
{
    [Header("تنظیمات حرکت")]
    /// <summary>
    /// سرعت حرکت بت‌سیگنال افقی.
    /// </summary>
    public float moveSpeed = 3f;

    /// <summary>
    /// محدوده حرکت افقی بت‌سیگنال (از -moveRangeX تا +moveRangeX)
    /// </summary>
    public float moveRangeX = 8f;

    /// <summary>
    /// حداکثر ارتفاع حرکت بت‌سیگنال
    /// </summary>
    public float maxHeight = 4f;

    /// <summary>
    /// حداقل ارتفاع حرکت بت‌سیگنال
    /// </summary>
    public float minHeight = 2f;

    /// <summary>
    /// فرکانس حرکت عمودی (کمتر = حرکت آرام‌تر)
    /// </summary>
    public float waveFrequency = 0.5f;

    /// <summary>
    /// دامنه حرکت عمودی بت‌سیگنال
    /// </summary>
    public float waveAmplitude = 2f;

    /// <summary>
    /// وضعیت روشن یا خاموش بودن بت‌سیگنال
    /// </summary>
    private bool isOn = false;

    /// <summary>
    /// ارجاع به SpriteRenderer برای نمایش یا مخفی کردن بت‌سیگنال
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// موقعیت فعلی بت‌سیگنال در صفحه
    /// </summary>
    private Vector2 currentPosition;

    /// <summary>
    /// شمارنده زمان برای محاسبه حرکت موجی و رفت و برگشتی
    /// </summary>
    private float timeCounter = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // در شروع مخفی باشد

        // تنظیم موقعیت اولیه در مرکز بالا
        currentPosition = new Vector2(0f, maxHeight);
        transform.position = currentPosition;
    }

    void Update()
    {
        //  B برای روشن یا خاموش کردن بت‌سیگنال با کلید 
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBatSignal();
        }

        // اگر روشن باشد، حرکت موجی و رفت و برگشتی را اجرا کن
        if (isOn && spriteRenderer.enabled)
        {
            MoveBatSignal();
        }
    }

    /// <summary>
    /// روشن یا خاموش کردن بت‌سیگنال
    /// </summary>
    void ToggleBatSignal()
    {
        isOn = !isOn;
        spriteRenderer.enabled = isOn;

        // اگر روشن شد، موقعیت فعلی را حفظ کن
        if (isOn)
        {
            currentPosition = transform.position;
        }
    }

    /// <summary>
    /// مدیریت حرکت بت‌سیگنال
    /// شامل حرکت افقی رفت و برگشتی و حرکت عمودی موجی
    /// </summary>
    void MoveBatSignal()
    {
        // افزایش شمارنده زمان برای حرکت
        timeCounter += Time.deltaTime * moveSpeed;

        // حرکت افقی: رفت و برگشتی بین -moveRangeX و +moveRangeX
        float xPos = Mathf.PingPong(timeCounter, moveRangeX * 2) - moveRangeX;

        // محاسبه حرکت عمودی به صورت موجی (سینوسی)
        float midHeight = (maxHeight + minHeight) / 2f;
        float verticalRange = (maxHeight - minHeight) / 2f;
        float yPos = midHeight + Mathf.Sin(timeCounter * waveFrequency) * verticalRange;

        // اعمال محدودیت‌ها برای اطمینان از باقی ماندن بت‌سیگنال در محدوده
        xPos = Mathf.Clamp(xPos, -moveRangeX, moveRangeX);
        yPos = Mathf.Clamp(yPos, minHeight, maxHeight);

        // به‌روزرسانی موقعیت
        currentPosition = new Vector2(xPos, yPos);
        transform.position = currentPosition;
    }
}
