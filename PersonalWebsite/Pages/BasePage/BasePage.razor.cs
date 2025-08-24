using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using PersonalWebsite.Components.GitHubLink;
public class BasePage : ComponentBase
{
    [Inject]
    protected IJSRuntime? JSRuntime { get; set; }
    protected bool isOdd = false;
    protected int windowWidth = 0;
    protected string hostName = "";
    protected string ContactEmail = "Mark.Hogan.La@outlook.com";
    protected string LinkedInProfile = "https://linkedin.com/in/MarkHoganInLa";
    protected string GitHubProfile = "https://github.com/KrazKjn";
    protected string BasePath = "/";
    protected string ContactPhone = "+1 (504) 722-4459";
    protected string TwitterProfile = string.Empty;
    protected string FacebookProfile = string.Empty;
    protected string InstagramProfile = string.Empty;

    protected bool isDevelopment = true;
    protected string baseHref = "/";
    // File path for the current page
    protected virtual string? FilePath { get; set; }
    protected string GitHubLinkUrl => $"https://github.com/KrazKjn/blazor_examples/tree/main/PersonalWebsite/{FilePath}";

    // Shared method
    protected async void LogMessage(string message)
    {
        Console.WriteLine($"[BasePage Log]: {message}");
        await LogToConsole(message);
    }

    // Lifecycle method override (optional)
    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        await LoadSiteConfig();
        windowWidth = await JSRuntime!.InvokeAsync<int>("getWindowWidth");
        hostName = await JSRuntime!.InvokeAsync<string>("getHostname");
        isDevelopment = hostName == "localhost";
        baseHref = isDevelopment ? "" : "/my-personal-blazor-website";
        await JSRuntime!.InvokeVoidAsync("verifyBackgroundImage");
    }

    protected async Task LoadSiteConfig()
    {
        try
        {
            string configJson = string.Empty;
            try
            {
                configJson = await System.IO.File.ReadAllTextAsync("data/siteconfig.json");
                await LogToConsole("Loaded: data/siteconfig.json");
            }
            catch { }
            if (string.IsNullOrEmpty(configJson))
            {
                try
                {
                    configJson = await System.IO.File.ReadAllTextAsync("/data/siteconfig.json");
                    await LogToConsole("Loaded: /data/siteconfig.json");
                } catch { }
            }
            if (string.IsNullOrEmpty(configJson))
            {
                using var httpClient = new HttpClient();
                configJson = await httpClient.GetStringAsync("https://krazkjn.github.io/my-personal-blazor-website/data/siteconfig.json");
                await LogToConsole("Loaded: https://krazkjn.github.io/my-personal-blazor-website/data/siteconfig.json");
            }
            await LogToConsole($"siteconfig.json\n{configJson}");
            var config = System.Text.Json.JsonDocument.Parse(configJson);
            await LogToConsole("Parsed json");
            if (config.RootElement.TryGetProperty("ContactEmail", out var emailProp))
            {
                ContactEmail = emailProp.GetString() ?? ContactEmail;
            }
            if (config.RootElement.TryGetProperty("LinkedInProfile", out var linkedInProp))
            {
                LinkedInProfile = linkedInProp.GetString() ?? LinkedInProfile;
            }
            if (config.RootElement.TryGetProperty("GitHubProfile", out var gitHubProp))
            {
                GitHubProfile = gitHubProp.GetString() ?? GitHubProfile;
            }
            if (config.RootElement.TryGetProperty("BasePath", out var basePath))
            {
                BasePath = basePath.GetString() ?? BasePath;
            }
            if (config.RootElement.TryGetProperty("ContactPhone", out var phoneProp))
            {
                ContactPhone = phoneProp.GetString() ?? ContactPhone;
            }
            if (config.RootElement.TryGetProperty("TwitterProfile", out var twitterProp))
            {
                TwitterProfile = twitterProp.GetString() ?? TwitterProfile;
            }
            if (config.RootElement.TryGetProperty("FacebookProfile", out var facebookProp))
            {
                FacebookProfile = facebookProp.GetString() ?? FacebookProfile;
            }
            if (config.RootElement.TryGetProperty("InstagramProfile", out var instagramProp))
            {
                InstagramProfile = instagramProp.GetString() ?? InstagramProfile;
            }
            await LogToConsole("Loaded SiteConfig.");
        }
        catch (Exception ex)
        {
            LogMessage($"Error loading site configuration: {ex.Message}");
        }
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

    protected static string RemoveUnicode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return new string(input.Where(c => c <= 127).ToArray());
    }

    protected static MarkupString RenderHtml(string? content) => new MarkupString(content ?? string.Empty);

    protected async Task LogToConsole(string message) =>
            await JSRuntime!.InvokeVoidAsync("consoleLogger.log", $"[{GetType().Name}] {message}");
}
