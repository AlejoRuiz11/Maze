using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnBoulderFall;      
    public static event Action OnPlayerHit;        
    public static event Action OnTrapTriggered;    

    public static void TriggerBoulderFall()
    {
        OnBoulderFall?.Invoke();
    }

    public static void TriggerPlayerHit()
    {
        OnPlayerHit?.Invoke();
    }

    public static void TriggerTrapTriggered()
    {
        OnTrapTriggered?.Invoke();
    }
}
