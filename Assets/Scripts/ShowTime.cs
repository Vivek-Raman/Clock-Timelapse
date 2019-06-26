using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTime : MonoBehaviour
{
    [Header("References")]
    public GameObject HourHand = null;
    public GameObject MinuteHand = null;

    [Header("Hand Speeds")]
    [SerializeField] [Range(0, 1)] private float HourSpeed = 0.1f;
    [SerializeField] [Range(0, 1)] private float MinSpeed = 0.1f;

    [Header("Debug")]
    [SerializeField] private float HourTarget = 0f;
    [SerializeField] private float MinTarget = 0f;

    [SerializeField] private bool isTimeAuto = true;
    [SerializeField] [Range(0, 23)] private int hour = 0;
    [SerializeField] [Range(0, 59)] private int min = 0;

    private void Start()
    {
        SetTargetAngles();
        HourHand.transform.rotation = Quaternion.Euler(0f, 0f, HourTarget);
        MinuteHand.transform.rotation = Quaternion.Euler(0f, 0f, MinTarget);
    }

    private void Update()
    {
        SetTargetAngles();
        HourHand.transform.rotation = Quaternion.RotateTowards(HourHand.transform.rotation, Quaternion.Euler(0f, 0f, HourTarget), HourSpeed);
        MinuteHand.transform.rotation = Quaternion.RotateTowards(MinuteHand.transform.rotation, Quaternion.Euler(0f, 0f, MinTarget), MinSpeed);
    }

    private void SetTargetAngles()
    {
        if (isTimeAuto)
        {
            hour = System.DateTime.Now.Hour;
            min = System.DateTime.Now.Minute;
        }
        HourTarget = (hour % 12) * 30;          // 1 hr = 30 degrees
        MinTarget = min * 6;                    // 1 min = 6 degrees
    }
}
