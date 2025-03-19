using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

public class BasePage : ComponentBase
{
    [Inject]
    protected IJSRuntime? JSRuntime { get; set; }

    protected bool isOdd = false;
    protected int windowWidth = 0;

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
}
