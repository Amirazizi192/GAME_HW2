using UnityEngine;

public class BatmanStateController : MonoBehaviour
{
    public enum BatmanState
    {
        Normal,
        Stealth,
        Alert
    }

    public BatmanState currentState = BatmanState.Normal;

    void Update()
    {
        HandleStateInput();
    }

    void HandleStateInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SetState(BatmanState.Stealth);

        if (Input.GetKeyDown(KeyCode.Space))
            SetState(BatmanState.Alert);

        if (Input.GetKeyDown(KeyCode.N))
            SetState(BatmanState.Normal);    
    }

    void SetState(BatmanState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case BatmanState.Normal:
                Debug.Log("Normal Mode");
                break;

            case BatmanState.Stealth:
                Debug.Log("Stealth Mode");
                break;

            case BatmanState.Alert:
                Debug.Log("Alert Mode");
                break;
        }
    }
}
