using UnityEngine;

public class BatmobileMovement : MonoBehaviour
{
    // -------------------- تنظیمات حرکت --------------------
    [Header("حرکت")]
    /// <summary>
    /// سرعت حرکت عادی ماشین.
    /// </summary>
    public float normalSpeed = 5f;

    /// <summary>
    /// سرعت حرکت هنگام فشار دادن کلید Shift (دویدن/بوست).
    /// </summary>
    public float boostSpeed = 12f;

    // -------------------- مراجع به اجزا --------------------
    [Header("مراجع")]
    /// <summary>
    /// Rigidbody2D برای حرکت فیزیکی ماشین.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// سرعت فعلی ماشین (عادی یا بوست یا مخفی‌کاری).
    /// </summary>
    private float currentSpeed;

    /// <summary>
    /// ارجاع به دوربین اصلی برای محدود کردن حرکت ماشین داخل صفحه.
    /// </summary>
    private Camera mainCamera;

    /// <summary>
    /// ارجاع به BatmanStateController برای بررسی حالت فعلی بتمن (Normal / Stealth / Alert).
    /// </summary>
    private BatmanStateController stateController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        stateController = GetComponent<BatmanStateController>();
    }

    void Update()
    {
        HandleMovement(); // پردازش حرکت بازیکن
        ClampPosition();  // جلوگیری از خارج شدن ماشین از محدوده صفحه
    }

    /// <summary>
    /// مدیریت حرکت ماشین بر اساس ورودی کاربر و حالت فعلی بتمن.
    /// </summary>
    void HandleMovement()
    {
        // ورودی حرکت جلو و عقب (W / S)
        float forwardInput = Input.GetAxis("Vertical");

        // ورودی حرکت به چپ و راست (A / D)
        float sideInput = 0f;
        if (Input.GetKey(KeyCode.A)) sideInput = -1f;
        if (Input.GetKey(KeyCode.D)) sideInput = 1f;

        // بررسی فشار کلید Shift برای دویدن/بوست
        bool isBoosting = Input.GetKey(KeyCode.LeftShift);

        // تعیین سرعت فعلی بر اساس حالت بتمن
        if (stateController != null && stateController.currentState == BatmanStateController.BatmanState.Stealth)
        {
            currentSpeed = normalSpeed * 0.2f;  // حالت مخفی‌کاری بسیار کند است
        }
        else
        {
            currentSpeed = isBoosting ? boostSpeed : normalSpeed;
        }

        // محاسبه بردار حرکت جلو/عقب و چپ/راست
        Vector2 forwardMove = transform.up * forwardInput * currentSpeed;
        Vector2 sideMove = transform.right * sideInput * currentSpeed;

        // اعمال سرعت نهایی به Rigidbody
        rb.linearVelocity = forwardMove + sideMove;
    }

    /// <summary>
    /// محدود کردن موقعیت ماشین در داخل محدوده تعریف شده صفحه.
    /// </summary>
    void ClampPosition()
    {
        // گرفتن موقعیت فعلی
        Vector3 pos = transform.position;

        // مرزهای دستی صفحه (محدوده بازی)
        float minX = -7.0f;
        float maxX =  7.0f;
        float minY = -4.0f;
        float maxY = -1.0f;

        // محدود کردن موقعیت ماشین داخل مرزها
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // اعمال موقعیت محدود شده
        transform.position = pos;
    }
}
