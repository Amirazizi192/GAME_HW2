using UnityEngine;

public class BatSignalController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float moveRangeX = 8f;
    public float maxHeight = 4f;   // حداکثر ارتفاع
    public float minHeight = 2f;   // حداقل ارتفاع (بجای -0.5)
    public float waveFrequency = 0.5f; // فرکانس موج (کمتر = حرکت آرامتر)
    public float waveAmplitude = 2f;   // دامنه موج (کمتر = حرکت کمتر عمودی)
    
    private bool isOn = false;
    private SpriteRenderer spriteRenderer;
    private Vector2 currentPosition;
    private float timeCounter = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // در شروع مخفی
        
        // تنظیم موقعیت اولیه در مرکز بالا
        currentPosition = new Vector2(0f, maxHeight);
        transform.position = currentPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleBatSignal();
        }

        if (isOn && spriteRenderer.enabled)
        {
            MoveBatSignal();
        }
    }

    void ToggleBatSignal()
    {
        isOn = !isOn;
        spriteRenderer.enabled = isOn;
        
        // اگر روشن شد، از همان موقعیت فعلی شروع کن
        if (isOn)
        {
            currentPosition = transform.position;
        }
    }

    void MoveBatSignal()
    {
        // افزایش زمان برای حرکت
        timeCounter += Time.deltaTime * moveSpeed;
        
        // **حرکت افقی**: رفت و برگشتی بین -moveRangeX تا +moveRangeX
        float xPos = Mathf.PingPong(timeCounter, moveRangeX * 2) - moveRangeX;

        float midHeight = (maxHeight + minHeight) / 2f;
        float verticalRange = (maxHeight - minHeight) / 2f;
        float yPos = midHeight + Mathf.Sin(timeCounter * waveFrequency) * verticalRange;
        
        
        // اعمال محدودیت‌ها (برای اطمینان)
        xPos = Mathf.Clamp(xPos, -moveRangeX, moveRangeX);
        yPos = Mathf.Clamp(yPos, minHeight, maxHeight);
        
        // آپدیت موقعیت
        currentPosition = new Vector2(xPos, yPos);
        transform.position = currentPosition;
    }}

