using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary
{
    public delegate float Function(float x,float z,float t);
    public static Function[] functions = {DrawSin,Wave,MultiWave,Ripple,RippleAnim};
    public enum FuncName {DrawSin,Wave,MultiWave,Ripple,RippleAnim } 
    public static float DrawSin(float x,float z,float t)
    {
        return Mathf.Sin( PI * (x + z + t))/2;
    }
    public static Function GetFunc(int index)
    {
        return functions[index];
    } 
    
    public static float Wave(float x,float z, float t)
    {
        float y = Sin(PI * (x + t));
        y += 0.5f * Sin(2f * PI * (z + t));
        return y / 1.5f;
    }

    public static float MultiWave(float x,float z, float t)
    {
        float y = Sin(PI * (x + 0.5f * t));
        y += 0.5f * Sin(2f * PI * (z + t));
        return y / 1.5f;
    }

    public static float Ripple(float x,float z, float t)
    {
        float d = Abs(x);
        return Sin(PI * 4.0f * d);
    }

    public static float RippleAnim(float x,float z, float t)
    {
        float d = Abs(x);
        float y = Sin(PI * (4.0f*d - t));
        return y / (1.0f + 10.0f * d);
    } 
}
