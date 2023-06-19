using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate Vector3 Function(float x,float z,float t);
    public static Function[] functions = {DrawSin,Wave,MultiWave,Ripple,Sphere};
    public enum FuncName {DrawSin,Wave,MultiWave,Ripple,Sphere} 
    public static Vector3 DrawSin(float u,float v,float t)
    {
        Vector3 p;
        p.x = u;
        p.z = v;
        p.y = Mathf.Sin( PI * ( u + v + t))/2;
        return p;
    }
    public static Function GetFunc(int index)
    {
        return functions[index];
    } 
    
    public static Vector3 Wave(float u,float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.z = v;
        float y = Sin(PI * (u + t));
        y += 0.5f * Sin(2f * PI * (v + t));
        p.y = y / 1.5f;
        return p;
    }

    public static Vector3 MultiWave(float u,float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.z = v;
        float y = Sin(PI * (u + 0.5f * t));
        y += 0.5f * Sin(2f * PI * (v + t));
        y += Sin(PI * (u + v + 0.25f * t));
        p.y = y * (1f / 2.5f);
        return p;
    }

    public static Vector3 Ripple(float u,float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.z = v;
        float d = Sqrt(u*u + v*v);
        float y = Sin(PI * (4f * d - t));
        p.y = y / (1 + 10 * d);
        return p;
    }

    public static Vector3 Sphere(float u,float v, float t)
    {
        Vector3 p;
        p.x = Sin(u  * PI);
        p.y = 0;
        p.z = Cos(u  * PI);
        return p;
    }
}
