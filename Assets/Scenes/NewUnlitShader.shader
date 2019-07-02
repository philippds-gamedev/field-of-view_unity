Shader "MyShaderName"
{
	Properties
	{
		// material properties here
	}
	SubShader // subshader for graphics hardware A
	{
		Pass
		{
		// pass commands ...
	}
	// more passes if needed
	}
		// more subshaders if needed
		FallBack "VertexLit" // optional fallback
}
