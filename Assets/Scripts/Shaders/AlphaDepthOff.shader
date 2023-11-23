Shader "Custom/AlphaDepthOff"
{
    //этот шейдер был необходим мне для отображения силуэта меша. он работает с прозрачнастю и отключает губину дабы прозрачные треугольники не наслаивались
     Properties
    {
        _Color ("Color", color) = (0,0,0,0.5)
        _MainTex("Texture", 2D) = "white"{}
        _FogColor("Fog colog", Color) = (0.5,0.5,0.5, 1)
        _FogMaxHeight("Fog max height", float) = 1
        _FogMinHeight("Fog min height", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            
            ZWrite Off
            CGPROGRAM
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 pos : WORLD_POS_VERTEX;
            };

            sampler2D _MainTex;
            float4 _Color;
            float4 _FogColor;
            float _FogMaxHeight;
            float _FogMinHeight;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.pos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv) * _Color;
                float lerpValue = clamp((i.pos.y - _FogMinHeight)/(_FogMaxHeight - _FogMinHeight), 0, 1);
                fixed4 finalColor = (0,0,0, color.a);
                finalColor.rgb = lerp(_FogColor.rgb, color.rgb, lerpValue);
                return finalColor;
            }
            ENDCG
        }
    }
}