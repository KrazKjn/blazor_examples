using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public class BasePage : ComponentBase
{
    [Inject]
    protected IJSRuntime? JSRuntime { get; set; }

    protected bool isOdd = false;
    protected int windowWidth = 0;
    protected string hostName = "";
    protected bool isDevelopment = true;
    protected string baseHref = "/";

    // Shared method
    protected void LogMessage(string message)
    {
        Console.WriteLine($"[BasePage Log]: {message}");
    }

    // Lifecycle method override (optional)
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        windowWidth = await JSRuntime!.InvokeAsync<int>("getWindowWidth");
        hostName = await JSRuntime!.InvokeAsync<string>("getHostname");
        isDevelopment = hostName == "localhost";
        baseHref = isDevelopment ? "" : "/my-personal-blazor-website";
        await JSRuntime!.InvokeVoidAsync("verifyBackgroundImage");
    }
    
    // Method to call a JavaScript function
    protected async Task InvokeJavaScriptFunctionAsync(string functionName, params object[] args)
    {
        await JSRuntime!.InvokeVoidAsync(functionName, args);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
        }
        await JSRuntime!.InvokeVoidAsync("setDynamicCssHeight");
    }

    protected string GetImagePath(string src)
    {
        if (src.StartsWith('/'))
            return $"{baseHref}{src}";
        return src;
    }
}
