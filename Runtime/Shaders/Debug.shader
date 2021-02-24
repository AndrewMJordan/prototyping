// Copyright (c) 2020, AndrewMJordan
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree

Shader "Andtech/Debug" {

	Properties {
		[KeywordEnum(Vertex UV, Vertex Color, View Direction, Dot, Normal, Tangent, Binormal)] _Mode("Debug Mode", Float) = 0.0
		[Toggle(COMPRESS)] _Compress("Compress", Float) = 0.0
	}

	SubShader {
		Tags {
			"RenderType"="Opaque"
		}
		
		LOD 100

		Pass {
			CGPROGRAM
			#pragma target 3.5
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature_local _MODE_VERTEX_UV _MODE_VERTEX_COLOR _MODE_VIEW_DIRECTION _MODE_DOT _MODE_NORMAL _MODE_TANGENT _MODE_BINORMAL
			#pragma shader_feature_local COMPRESS
			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 uv : TEXCOORD0;
				fixed4 color : COLOR;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float4 obj : POSITION1;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float2 uv : TEXCOORD0;
				fixed4 color : COLOR;
			};

			v2f vert (appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.obj = v.vertex;
				o.uv = v.uv;
				o.color = v.color;
				o.normal = UnityObjectToWorldNormal(v.normal);
				o.tangent = float4(UnityObjectToWorldDir(v.tangent), v.tangent.w);
				return o;
			}

			fixed4 compress(fixed4 color) {
				return fixed4(0.5 + 0.5 * color.rgb, 1.0);
			}
			
			fixed4 frag(v2f i) : SV_Target{
				fixed4 color = fixed4(1, 1, 0, 1);
#ifdef _MODE_VERTEX_UV
				color = fixed4(i.uv.xy, 0, 1);
#endif
#ifdef _MODE_VERTEX_COLOR
				color = fixed4(i.color.rgb, 1);
#endif
#ifdef _MODE_DOT
				float3 normal = i.normal;
				normal = normalize(normal);
				float3 view = WorldSpaceViewDir(i.obj);
				view = normalize(view);
				color = dot(normal, view);
#endif
#ifdef _MODE_VIEW_DIRECTION
				float3 view = WorldSpaceViewDir(i.obj);
				view = normalize(view);
				color = fixed4(view.xyz, 1.0);
#if COMPRESS
				color = compress(color);
#endif
#endif
#if _MODE_NORMAL
				float3 normal = i.normal;
				normal = normalize(normal);
				color = fixed4(normal.xyz, 1.0);
#if COMPRESS
				color = compress(color);
#endif
#endif
#if _MODE_TANGENT
				float3 tangent = i.tangent;
				tangent = normalize(tangent);
				color = fixed4(tangent.xyz, 1.0);
#if COMPRESS
				color = compress(color);
#endif
#endif
#if _MODE_BINORMAL
				float3 binormal = cross(i.normal, i.tangent.xyz) * i.tangent.w;
				binormal = normalize(binormal);
				color = fixed4(binormal.xyz, 1.0);
#if COMPRESS
				color = compress(color);
#endif
#endif
				return color;
			}
			ENDCG
		}
	}
}
