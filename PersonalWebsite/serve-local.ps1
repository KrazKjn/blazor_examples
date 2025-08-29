param (
    [string]$mode = "default"
)

function Update-Version {
    $csprojPath = ".\PersonalWebsite.csproj"
    if (-Not (Test-Path $csprojPath)) {
        Write-Host "Project file not found: $csprojPath" -ForegroundColor Red
        exit 1
    }

    [xml]$xml = Get-Content $csprojPath
    $ns = @{msb = "http://schemas.microsoft.com/developer/msbuild/2003"}

    $versionNode = $xml.Project.PropertyGroup.Version
    if (-Not $versionNode) {
        Write-Host "No <Version> tag found in $csprojPath" -ForegroundColor Red
        exit 1
    }

    $currentVersion = $versionNode[0]
    Write-Host "Current version: $currentVersion" -ForegroundColor Yellow

    $parts = $currentVersion.Split('.')
    if ($parts.Count -ne 4) {
        Write-Host "Version format must be Major.Minor.Build.Revision (e.g., 2.0.0.0)" -ForegroundColor Red
        exit 1
    }

    $parts[3] = [int]$parts[3] + 1
    $newVersion = "$($parts[0]).$($parts[1]).$($parts[2]).$($parts[3])"

    # Update all version fields
    $xml.SelectSingleNode("//Version").InnerText = $newVersion
    $xml.SelectSingleNode("//AssemblyVersion").InnerText = $newVersion
    $xml.SelectSingleNode("//FileVersion").InnerText = $newVersion

    $fullPath = (Resolve-Path $csprojPath).Path
    $xml.Save($fullPath)
    Write-Host "Updated version to: $newVersion" -ForegroundColor Green
}

function Publish-Site {
    Write-Host "Publishing Blazor WebAssembly app..." -ForegroundColor Cyan
    dotnet publish .\PersonalWebsite.csproj -c Release
}

function Build-Site {
    Write-Host "Building Blazor WebAssembly app (Local Testing)..." -ForegroundColor Cyan
    dotnet build .\PersonalWebsite.csproj -c Release -o publish-temp

    # Fast delete dist folder
    if (Test-Path "dist") {
        Write-Host "Removing existing dist folder..." -ForegroundColor Yellow
        cmd /c "rd dist /s /q"
    }

    $publishedRoot = "publish-temp\wwwroot"
    if (-Not (Test-Path $publishedRoot)) {
        Write-Host "$publishedRoot not found!" -ForegroundColor Red
        exit 2
    }

    # Create dist and subfolder
    Write-Host "Creating dist folder..." -ForegroundColor Cyan
    New-Item -ItemType Directory -Path "dist" -Force | Out-Null

    # Fast move published wwwroot into subfolder
    $distWebSite = "dist\my-personal-blazor-website"
    Write-Host "Moving wwwroot to dist as my-personal-blazor-website..." -ForegroundColor Cyan
    cmd /c "move publish-temp\wwwroot $distWebSite"

    if (-Not (Test-Path $distWebSite)) {
        Write-Host "$distWebSite not found!" -ForegroundColor Red
        exit 2
    }

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
    "publish" {
        Update-Version
        Publish-Site
    }
    default {
        Build-Site
        Run-Server
    }
}
