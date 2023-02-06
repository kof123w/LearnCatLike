using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] public Transform _pointPrefabs;
    [Range(0, 100)] public float _pointNum = 10;
    
    //初始化图形代码
    void Start()
    {
        float step = 2.0f / _pointNum;
       //统一修改预制体大小
       _pointPrefabs.localScale = Vector3.one * step ;
       for (int i = 0;i < _pointNum;i++)
       {
           Transform point = Instantiate(_pointPrefabs);
           //设置创建的子对象
           point.SetParent(transform); 
       }
    }
    
    //让图像动起来
    void Update()
    {
        float time = Time.time;
        float step = 2.0f / _pointNum;
        for (int i = 0; i < _pointNum; i++)
        { 
            Vector3 position = Vector3.zero;
            Transform point = transform.GetChild(i);
            position.x = (i + 0.5f) * step - 1f;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time)) ;
            point.position = position;
        }
    }
}
