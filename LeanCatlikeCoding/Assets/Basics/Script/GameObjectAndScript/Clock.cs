using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// 时钟脚本
/// </summary>
public class Clock : MonoBehaviour
{
    //引用时针、分针、秒针的pivot的transform
    [HideInInspector] private Transform _hoursPivot,_minutesPivot,_secondsPivot; 
    [HideInInspector] private const float  _hoursToDegrees = -30f, _minutesToDegrees = -6f, _secondsToDegrees = -6f;
   
    private void Start()
    {
        _hoursPivot = GameObject.Find("Clock/HoursArmPivot").transform;
        _minutesPivot = GameObject.Find("Clock/MinutesArmPivot").transform;
        _secondsPivot = GameObject.Find("Clock/SecondsArmPivot").transform;
    }

    private void Update()
    {
        //var time = DateTime.Now;

        //_hoursPivot.localRotation = Quaternion.Euler(new Vector3(0, 0,hoursToDegrees * time.Hour));
        //_minutesPivot.localRotation = Quaternion.Euler(new Vector3(0,0,minutesToDegrees * time.Minute));
        //_secondsPivot.localRotation = Quaternion.Euler(new Vector3(0,0,secondsToDegrees * time.Second));
        
        //_hoursPivot.localRotation = Quaternion.Euler(new Vector3(0, 0,hoursToDegrees * time.Hour));
        //_minutesPivot.localRotation = Quaternion.Euler(new Vector3(0,0,minutesToDegrees * time.Minute));
        //_secondsPivot.localRotation = Quaternion.Euler(new Vector3(0,0,secondsToDegrees * time.Second));
        
        TimeSpan time = DateTime.Now.TimeOfDay;
        _hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, _hoursToDegrees   *(float)time.TotalHours);
        _minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, _minutesToDegrees *(float)time.TotalMinutes);
        _secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, _secondsToDegrees *(float)time.TotalSeconds);
    }
}
