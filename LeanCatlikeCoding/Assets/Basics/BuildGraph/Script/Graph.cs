using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] public Transform pointPrefabs;
    [SerializeField] public int createPointNum = 100;  //创建点的数量
    [SerializeField] public float pointDist = 0.1f;    //点和点之间x轴的距离 
    [SerializeField] public float zPointDist = 0.05f;  //点和点之间z轴的距离
    [SerializeField] public int max = 100;
    [SerializeField] public float scale = 1.0f;
    private Transform[] _transforms;
    private Transform _trans; 
    
    void Start()
    {
        _trans = transform; 
       //统一修改预制体大小
       pointPrefabs.localScale = new Vector3(scale,scale,scale);
       _transforms = new Transform[createPointNum];
       for (int i = 0;i<createPointNum;i++)
       {
           Transform newTrans = Instantiate(pointPrefabs);
           newTrans.gameObject.name = $"point{i}";
           newTrans.SetParent(_trans); 
           _transforms[i] = newTrans;
       }
    } 
   
    //让图像动起来
    void Update()
    {
        Tick();
    }

    [SerializeField] public FunctionLibrary.FuncName funcIndex = FunctionLibrary.FuncName.DrawSin;
    [HideInInspector] private Vector3 _cache = Vector3.zero; 
    void Tick()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunc((int)funcIndex);
        float time = Time.time;
        int index = GetStartX();
        int zIndex = 0;
        for (int i = 0;i < _transforms.Length;i++)
        {
            float x = index * pointDist;
            float z = zIndex * zPointDist;
            _cache.x = x;
            _cache.y = f(x,z,time);
            _cache.z = z;
            _transforms[i].localPosition = _cache;
            index++;
            if (index >= max){
                index = GetStartX();
                zIndex++;
            }
        }
    }
    
    int GetStartX()
    {
        return -_transforms.Length / 2 <= -max ? -max : -_transforms.Length / 2;
    }
}
