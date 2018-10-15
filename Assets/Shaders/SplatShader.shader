Shader "Custom/SplatShader" 
{
	Properties 
	{
		//物体颜色
		_Color ("Color", Color) = (1,1,1,1)
		//物体主纹理
		_MainTex ("Main Texture", 2D) = "white" {}
		[HideInInspector]
		_InkTex("Ink Texture", 2D) = "" {}

	}
	SubShader 
	{
		pass
		{
			CGPROGRAM
			#include "UnityCG.cginc"
			#pragma vertex vert 
			#pragma fragment frag 

			float4 _Color;
			float4 _MainTex_ST;
			sampler2D _MainTex;
			sampler2D _InkTex;
			float4 _InkTex_ST;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv_main : TEXCOORD0;
				float2 uv_ink : TEXCOORD1;
				float4 color : COLOR;
			};

			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.uv_main = v.texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
				o.uv_ink = v.texcoord * _InkTex_ST.xy + _InkTex_ST.zw;
				return o;
			}

			fixed4 frag(v2f i) : SV_TARGET
			{
				fixed3 color;
				fixed4 mainColor = tex2D(_MainTex, i.uv_main);
				fixed4 splatColor = tex2D(_InkTex, i.uv_ink);
				color = lerp(mainColor, splatColor, splatColor.a);
				return fixed4(color, mainColor.a + splatColor.a);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
