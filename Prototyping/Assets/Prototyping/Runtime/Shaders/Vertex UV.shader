﻿
Shader "Andtech/Vertex UV" {

	SubShader {
		Tags {
			"RenderType"="Opaque"
		}
		
		LOD 100

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 col : COLOR0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.col = fixed4(v.uv, 0, 1);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target {
				return i.col;
			}
			ENDCG
		}
	}
}
