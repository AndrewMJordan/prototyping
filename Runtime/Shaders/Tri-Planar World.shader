// Copyright (c) 2021, AndtechGames
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree

//Source https ://gist.github.com/radiatoryang/4725041
Shader "Andtech/Triplanar" {

	Properties{
		  _Top("Top", 2D) = "white" {}
		  _Side("Side", 2D) = "white" {}
		  _Bottom("Bottom", 2D) = "white" {}
	}

	SubShader{
		Tags {
			"Queue" = "Geometry"
			"IgnoreProjector" = "False"
			"RenderType" = "Opaque"
		}

		Cull Back
		ZWrite On

		CGPROGRAM
		#pragma surface surf Lambert
		#pragma exclude_renderers flash

		sampler2D _Top;
		float4 _Top_ST;
		sampler2D _Side;
		float4 _Side_ST;
		sampler2D _Bottom;
		float4 _Bottom_ST;

		struct Input {
			float3 worldPos;
			float3 worldNormal;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			float3 projNormal = saturate(pow(IN.worldNormal * 1.4, 4));

			// TOP / BOTTOM
			float3 y = 0;
			if (IN.worldNormal.y > 0) {
				y = tex2D(_Top, frac(float2(IN.worldPos.x, IN.worldPos.z) * _Top_ST.xy + _Top_ST.zw)) * abs(IN.worldNormal.y);
			}
			else {
				y = tex2D(_Bottom, frac(float2(IN.worldPos.x, -IN.worldPos.z) * _Bottom_ST.xy + _Bottom_ST.zw)) * abs(IN.worldNormal.y);
			}

			// SIDE X
			float3 x = 0;
			if (IN.worldNormal.x > 0) {
				x = tex2D(_Side, frac(float2(IN.worldPos.z, IN.worldPos.y) * _Side_ST.xy + _Side_ST.zw)) * abs(IN.worldNormal.x);
			}
			else {
				x = tex2D(_Side, frac(float2(-IN.worldPos.z, IN.worldPos.y) * _Side_ST.xy + _Side_ST.zw)) * abs(IN.worldNormal.x);
			}

			// SIDE Z
			float3 z;
			if (IN.worldNormal.z > 0) {
				z = tex2D(_Side, frac(float2(-IN.worldPos.x, IN.worldPos.y) * _Side_ST.xy + _Side_ST.zw)) * abs(IN.worldNormal.z);
			}
			else {
				z = tex2D(_Side, frac(float2(IN.worldPos.x, IN.worldPos.y) * _Side_ST.xy + _Side_ST.zw)) * abs(IN.worldNormal.z);
			}

			o.Albedo = z;
			o.Albedo = lerp(o.Albedo, x, projNormal.x);
			o.Albedo = lerp(o.Albedo, y, projNormal.y);
		}
		ENDCG
	}

	Fallback "Diffuse"
}