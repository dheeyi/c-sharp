# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run Commands

```bash
# Build the project
dotnet build ProductsWeb.csproj

# Run the project (starts at https://localhost:5001 by default)
dotnet run

# Run with hot reload for development
dotnet watch run
```

## Project Overview

This is a **Blazor Server** web application targeting .NET 10.0 with interactive server-side rendering.

### Architecture

- **Render Mode**: Interactive Server Components (`AddInteractiveServerComponents`)
- **Routing**: Defined via `@page` directives in Razor components, handled by `Routes.razor`
- **Layout**: `MainLayout.razor` provides the default page layout with sidebar navigation
- **Static Assets**: Bootstrap CSS/JS in `wwwroot/lib/bootstrap/`, app styles in `wwwroot/app.css`

### Key Files

- `Program.cs` - Application entry point, configures services and middleware
- `Components/App.razor` - Root HTML document structure
- `Components/Routes.razor` - Router configuration with NotFound handling
- `Components/Layout/MainLayout.razor` - Main page layout with navigation
- `Components/Pages/` - Page components with `@page` route directives
