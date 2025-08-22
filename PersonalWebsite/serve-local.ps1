param (
    [string]$mode = "default"
)

function Build-Site {
    Write-Host "Publishing Blazor WebAssembly app..." -ForegroundColor Cyan
    dotnet publish .\PersonalWebsite.csproj -c Release -o publish-temp

    # Fast delete dist folder
    if (Test-Path "dist") {
        Write-Host "Removing existing dist folder..." -ForegroundColor Yellow
        cmd /c "rd dist /s /q"
    }

    # Create dist and subfolder
    Write-Host "Creating dist/my-personal-blazor-website structure..." -ForegroundColor Cyan
    New-Item -ItemType Directory -Path "dist" -Force | Out-Null
    New-Item -ItemType Directory -Path "dist\my-personal-blazor-website" -Force | Out-Null

    # Fast move published wwwroot into subfolder
    Write-Host "Moving wwwroot to dist/my-personal-blazor-website..." -ForegroundColor Cyan
    cmd /c "move publish-temp\wwwroot dist\my-personal-blazor-website"

    # Clean up publish-temp
    Write-Host "Cleaning up publish-temp..." -ForegroundColor Yellow
    cmd /c "rd publish-temp /s /q"
}

function Run-Server {
    $indexPath = "dist\my-personal-blazor-website\index.html"
    if (-Not (Test-Path $indexPath)) {
        Write-Host "No build found. Running build first..." -ForegroundColor Yellow
        Build-Site
    }

    Write-Host "Starting local server at http://localhost:5174/my-personal-blazor-website/" -ForegroundColor Green
    Set-Location "dist"
    try {
        # Run Python server in PowerShell so it blocks until CTRL-C
        python -m http.server 5174
    }
    finally {
        # Revert to parent folder after server exits
        Set-Location ".."
        Write-Host "Returned to parent directory." -ForegroundColor Green
    }
}

switch ($mode.ToLower()) {
    "build" {
        Build-Site
    }
    "run" {
        Run-Server
    }
    default {
        Build-Site
        Run-Server
    }
}
