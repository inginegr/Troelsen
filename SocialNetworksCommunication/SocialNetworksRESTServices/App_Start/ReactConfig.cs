using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SocialNetworksRESTServices.ReactConfig), "Configure")]

namespace SocialNetworksRESTServices
{
	public static class ReactConfig
	{
		public static void Configure()
		{
            // ����������� ������ V8
            JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JsEngineSwitcher.Current.EngineFactories.AddV8();
        }
	}
}