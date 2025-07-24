# 🚀 Blazor App: PersonalWebsite

A modern single-page application built with Blazor [WebAssembly or Server] using .NET 8.0+. This README includes guidance for running, debugging, publishing, and managing packages throughout the development lifecycle.

---

## 🏁 Getting Started

### 🔧 Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) + C# Extension
- (Optional) Node.js + npm (for static assets or JavaScript interop)

---

## ▶️ Running the App

### ⌨️ Using .NET CLI
```bash
dotnet run

 Visual Studio
- Open the .sln file
- Press F5 to run with debugger or Ctrl+F5 for without
Default URLs:
- https://localhost:5001/
- http://localhost:5000/

🐞 Debugging
In Visual Studio
- Set breakpoints in .razor, .cs, or services
- Use Hot Reload to live-refresh Blazor components (Server + WebAssembly)
In VS Code
- Configure .vscode/launch.json to target .NET Core
- Use Chrome DevTools for Blazor WebAssembly debugging

📦 Package Management
Add a NuGet Package
dotnet add package [PackageName]


Remove a Package
dotnet remove package [PackageName]


List Installed Packages
dotnet list package


Tip: Keep .csproj dependencies lean and version-controlled


🚀 How to Build & Publish
🌐 Blazor WebAssembly
dotnet publish -c Release


Output:
bin/Release/net8.0/publish/wwwroot/


Use for deployment to:
- GitHub Pages
- Azure Static Web Apps
- Netlify, Cloudflare Pages
🖥️ Blazor Server
dotnet publish -c Release -o ./publish


Deploy /publish to:
- IIS (Windows Server)
- Azure App Service
- Docker container with .NET runtime

🧪 Testing
Run Unit Tests
dotnet test


Use xUnit, MSTest, or NUnit depending on project setup
Static Analysis
- Enable analyzers in .editorconfig
- Leverage GitHub Copilot or AI tools for code health and refactoring

📂 Project Structure
├── Pages/             # UI Components (.razor)
├── Shared/            # Reusable Layouts
├── Services/          # API/Data Services
├── wwwroot/           # Static Content
├── App.razor          # Router Logic
├── Program.cs         # App Entry Point
└── [Project].csproj   # Package References and Build Targets