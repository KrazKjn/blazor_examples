using Microsoft.AspNetCore.Components;

public class BaseDataPage<TItem> : BasePage
{
    [Inject]
    protected HttpClient Http { get; set; } = default!; // Dependency injection for HttpClient

    protected List<TItem>? Items { get; private set; } = new List<TItem>();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }

    // Example method to load data dynamically (override this in derived classes)
    protected async virtual Task<List<TItem>?> LoadItemsAsync(string dataPath)
    {
        LogMessage($"Loading JSON file:\n{dataPath} ...");

        var response = await Http.GetStringAsync(dataPath);

        LogMessage($"Loading JSON file:\n{dataPath} ... Done.");
        LogMessage($"JSON:\n{response}");

        return System.Text.Json.JsonSerializer.Deserialize<List<TItem>>(response);
    }

    // Load data into the Items collection
    protected async Task LoadDataAsync(string dataPath)
    {
        if (string.IsNullOrEmpty(dataPath))
        {
            throw new ArgumentException("The data path cannot be null or empty.", nameof(dataPath));
        }
        Items = await LoadItemsAsync(dataPath);
        if (Items == null)
        {
            LogMessage($"No items to Load.");
        }
        else
        {
            LogMessage($"Loaded {Items.Count} items.");
        }
    }
}
