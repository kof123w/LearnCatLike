// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/PointShader"
{
    SubShader
    {
       Tags { "RenderType" = "Opaque"}
       LOD 200
       
       Pass{
           CGPROGRAM 
           //声明一个顶点着色器
           #pragma vertex vert
            //声明一个片元着色器
           #pragma fragment frag
           
           //引入一下Unity自带的CG库UnityCG.cginc
           #include "UnityCG.cginc"
           //声明一个结构体用于输入顶点着色器
           struct ad_data{
              float4 vertPos:POSITION;   //告诉结构体从模型空间里面拿坐标
           };
           
           //声明一个结构体用于顶点着色器输出，片元着色器输入
           struct v2f{
              float4 fragPos:SV_POSITION;  //告诉结构体从顶点着色器输出处那顶点坐标
              float4 fragData:TEXCOORD0;    //把数据输出到TEXCOORD0处进行存放
           };
           
           //编写顶点着色器函数。SV_POSITION为输出位置
           v2f vert(ad_data i):SV_POSITION{
                v2f o;    //声明输出结构体
                //UnityObjectToClipPos为Unity Shader内置函数。从模型空间坐标转换成裁剪空间坐标 
                o.fragPos = UnityObjectToClipPos(i.vertPos);  
                o.fragData = float4(i.vertPos.xyzw);
                return o;  //最终输出这个结构体
           } 
           
           //编写片元着色器函数。是一个输出屏幕上每一个像素点的函数。SV_TARGET为该函数输出位置
           float4 frag(v2f i):SV_TARGET{ 
               float4 color;
               color.rgb = normalize(i.fragData);
               color.a = 1;
               return color;
           }
           
           ENDCG
       }
    }
     
    FallBack "Diffuse"
}
