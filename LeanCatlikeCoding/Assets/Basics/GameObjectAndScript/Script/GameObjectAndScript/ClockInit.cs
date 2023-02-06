using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockInit : MonoBehaviour
{
    //存放时钟十二个指示的引用
    [HideInInspector] private List<Transform> _hourIndocators = new List<Transform>();
    //x长度为4
    [HideInInspector] private float _x = 4.0f;
    //y长度为4
    [HideInInspector] private float _y = 4.0f; 
    
    private void Awake()
    { 
        Transform clockTran = GameObject.Find("Clock").transform;
        for (int i = 1; i < 13; i++)
        {
            _hourIndocators.Add(clockTran.GetChild(i));
        }
        
        //计算各个指示器的位置和旋转 
        float radius = 360.0f / 12.0f;
        //刻度1 - 12
        for (int i = 0;i < _hourIndocators.Count;i++)
        {
            float sin =  Mathf.Sin(radius * i * Mathf.Deg2Rad);
            float cos =  Mathf.Cos(radius * i * Mathf.Deg2Rad);
            _hourIndocators[i].localPosition = new Vector3(_x * sin ,_y * cos , -0.25f);
            _hourIndocators[i].localRotation = Quaternion.Euler(new Vector3(0.0f,0.0f,- radius * i));
        }
    } 
}
