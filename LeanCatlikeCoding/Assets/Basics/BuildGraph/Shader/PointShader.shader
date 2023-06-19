shader "Custom/PointShader"
{
    
    SubShader{
        Tags { "RenderType" = "Opaque"}
        LOD 200
        
        Pass{
            CGPROGRAM
            #pragma target 3.0 
            #pragma vertex vert       //定义一个顶点着色器 
            #pragma fragment frag     //定义一个片元着色器
            
            struct adp_data
            {
                float4 vert:POSITION;
            };

            struct v2f
            {
                float4 vert:SV_POSITION;
                fixed4 color:TEXCOORD0;
            };

            v2f vert(adp_data i)
            {
                v2f o;
                o.vert = UnityObjectToClipPos(i.vert);
                o.color = mul(unity_ObjectToWorld,i.vert);
                return o;
            }

            fixed4 frag(v2f i):SV_Target
            {
                fixed4 outColor = i.color;
                outColor = saturate(outColor + (0.5,0.5,0.5));
                return outColor;
            }
            
            ENDCG
        }
    }
    FallBack "Diffuse"
}