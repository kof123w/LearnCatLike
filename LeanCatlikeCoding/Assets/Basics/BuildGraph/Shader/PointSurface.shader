Shader "Graph/PointSurface" 
{
    properties
    {
        _Smoothness("Smoothness" ,Range(0,1)) = 0.5
    }

     SubShader
    {
       Tags{ "RenderType" = "Opaque"}
       LOD 200
       
       CGPROGRAM
       #pragma surface surf Standard fullforwardshadows
       #pragma target 3.0

       float _Smoothness;
       struct Input
       {
           float3 worldPos;
       };
       
       void surf(Input input, inout SurfaceOutputStandard o)
       {
            o.Smoothness = _Smoothness;
            o.Albedo  = input.worldPos;
       }
        
       ENDCG
    }
    FallBack "Diffuse"
}