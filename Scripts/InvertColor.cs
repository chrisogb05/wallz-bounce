using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(InvertColorRenderer), PostProcessEvent.AfterStack, "Custom/Invert Color")]
public sealed class InvertColor : PostProcessEffectSettings
{
}

public sealed class InvertColorRenderer : PostProcessEffectRenderer<InvertColor>
{
	public override void Render(PostProcessRenderContext context)
	{
		var sheet = context.propertySheets.Get(Shader.Find("Custom/Invert Color"));
		context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
	}
}