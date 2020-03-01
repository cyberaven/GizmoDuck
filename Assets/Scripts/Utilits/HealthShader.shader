Shader "Custom/HealthShader"
{
	Properties
	{
		//[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		[PerRendererData] _Health("Select", Float) = 1
		[PerRendererData] _Hit("Hit", Float) = 1
		_HealthColor("_HealthColor", Color) = (0,1,0,1)
		_HitColor("_HitColor", Color) = (1,1,1,1)
		_LoseColor("_LoseColor", Color) = (1,0,0,1)
	}

		SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				float4 color : COLOR;
				float2 texcoord  : TEXCOORD0;
			};

			float4 _HealthColor, _HitColor, _LoseColor;
			float _Health, _Hit;
			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color;
				return OUT;
			}

			sampler2D _MainTex;


			float4 frag(v2f IN) : SV_Target
			{
				float t = IN.texcoord.x;
			if (t < _Health)
				return _HealthColor;
			if (t < _Hit)
				return _HitColor;
				return _LoseColor;
			}
		ENDCG
		}
	}
}
