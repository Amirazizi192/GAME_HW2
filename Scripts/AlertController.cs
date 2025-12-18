using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AlertController : MonoBehaviour
{
    [Header("نورهای دوبعدی")]
    /// <summary>
    /// نور قرمز چشمک‌زن برای حالت هشدار.
    /// وقتی حالت هشدار فعال شود، این نور به صورت متناوب روشن و خاموش می‌شود.
    /// </summary>
    public Light2D redLight;

    /// <summary>
    /// نور آبی چشمک‌زن برای حالت هشدار.
    /// وقتی حالت هشدار فعال شود، این نور به صورت متناوب روشن و خاموش می‌شود.
    /// </summary>
    public Light2D blueLight;

    [Header("صدا")]
    /// <summary>
    /// منبع صدا برای پخش آلارم در حالت هشدار.
    /// </summary>
    public AudioSource alarmAudio;

    /// <summary>
    /// فاصله زمانی بین تغییر وضعیت چشمک نورها (بر حسب ثانیه)
    /// </summary>
    public float flashInterval = 0.5f;

    /// <summary>
    /// وضعیت فعال بودن حالت هشدار. اگر درست باشد، نورها و صدا فعال هستند.
    /// </summary>
    private bool isAlert = false;

    /// <summary>
    /// شمارنده زمان برای مدیریت چشمک نورها.
    /// </summary>
    private float timer = 0f;

    void Update()
    {
        if (isAlert)
        {
            // افزایش شمارنده زمان با گذشت هر فریم
            timer += Time.deltaTime;

            // تغییر وضعیت نورها وقتی تایمر به مقدار flashInterval رسید
            if (timer >= flashInterval)
            {
                timer = 0f;
                if (redLight != null) redLight.enabled = !redLight.enabled;
                if (blueLight != null) blueLight.enabled = !blueLight.enabled;
            }

            // اگر صدا فعال نیست، آن را شروع می‌کند
            if (alarmAudio != null && !alarmAudio.isPlaying)
                alarmAudio.Play();
        }
        else
        {
            // خاموش کردن نورها و قطع صدا هنگام خروج از حالت هشدار
            if (redLight != null) redLight.enabled = false;
            if (blueLight != null) blueLight.enabled = false;
            if (alarmAudio != null && alarmAudio.isPlaying)
                alarmAudio.Stop();
        }
    }

    /// <summary>
    /// فعال یا غیرفعال کردن حالت هشدار.
    /// این تابع توسط سایر بخش‌های برنامه فراخوانی می‌شود.
    /// </summary>
    /// <param value>درست برای فعال کردن حالت هشدار، نادرست برای غیرفعال کردن</param>
    public void SetAlert(bool value)
    {
        isAlert = value;
    }
}
