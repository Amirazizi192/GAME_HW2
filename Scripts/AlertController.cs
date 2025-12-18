// using UnityEngine;

// public class AlertController : MonoBehaviour
// {
//     [Header("Lights")]
//     public Light2D  redLight;
//     public Light2D  blueLight;

//     [Header("Audio")]
//     public AudioSource alarmAudio;

//     [Header("Settings")]
//     public float flashInterval = 0.5f;

//     private bool isAlert = false;
//     private float timer = 0f;

//     void Update()
//     {
//         if (isAlert)
//         {
//             timer += Time.deltaTime;

//             if (timer >= flashInterval)
//             {
//                 timer = 0f;
//                 if (redLight != null) redLight.enabled = !redLight.enabled;
//                 if (blueLight != null) blueLight.enabled = !blueLight.enabled;
//             }

//             if (alarmAudio != null && !alarmAudio.isPlaying)
//                 alarmAudio.Play();
//         }
//         else
//         {
//             if (redLight != null) redLight.enabled = false;
//             if (blueLight != null) blueLight.enabled = false;
//             if (alarmAudio != null && alarmAudio.isPlaying)
//                 alarmAudio.Stop();
//         }
//     }

//     public void SetAlert(bool value)
//     {
//         isAlert = value;
//         Debug.Log("Alert is now: " + isAlert);
//     }
// }
using UnityEngine;
using UnityEngine.Rendering.Universal; // حتما اضافه کن

public class AlertController : MonoBehaviour
{
    [Header("2D Lights")]
    public Light2D redLight;
    public Light2D blueLight;

    [Header("Audio")]
    public AudioSource alarmAudio;

    public float flashInterval = 0.5f;
    private bool isAlert = false;
    private float timer = 0f;

    void Update()
    {
        if(isAlert)
        {
            timer += Time.deltaTime;
            if(timer >= flashInterval)
            {
                timer = 0f;
                if(redLight != null) redLight.enabled = !redLight.enabled;
                if(blueLight != null) blueLight.enabled = !blueLight.enabled;
            }

            if(alarmAudio != null && !alarmAudio.isPlaying)
                alarmAudio.Play();
        }
        else
        {
            if(redLight != null) redLight.enabled = false;
            if(blueLight != null) blueLight.enabled = false;
            if(alarmAudio != null && alarmAudio.isPlaying)
                alarmAudio.Stop();
        }
    }

    public void SetAlert(bool value)
    {
        isAlert = value;
        Debug.Log("Alert is now: " + isAlert);
    }
}
