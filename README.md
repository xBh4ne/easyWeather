# ☀️ EasyWeather

EasyWeather is a lightweight ASP.NET Core MVC web application that shows the current weather and an hourly forecast for any city in the world. Weather data comes from the [OpenWeather](https://openweathermap.org/) API, and the interface is built around a full-screen animated background that changes with the weather conditions.

Type at least three characters of a city name, pick one of the live suggestions, and EasyWeather opens a forecast page with the current temperature, condition, wind speed, precipitation probability, daylight hours and an hour-by-hour breakdown.

## ✨ Features

- **City search with live suggestions** — powered by the OpenWeather Geocoding API, no page reload required.
- **Hourly forecast** — 4-day hourly forecast served by the OpenWeather forecast endpoint.
- **Responsive weather page** — current conditions plus a horizontally scrollable hourly card list.
- **Dynamic backgrounds** — looping video backgrounds for clear, cloudy, scattered and broken cloud conditions.
- **Condition-aware icons** — weather icons are mapped from the forecast description on the client side.
- **XML endpoint** — the forecast is also exposed as machine-readable XML at `/weather/get`.
- **Docker-ready** — a published image is available on Docker Hub as [`unicamjason/easyweather`](https://hub.docker.com/r/unicamjason/easyweather).

## 🧰 Tech Stack

| Layer | Technology |
| --- | --- |
| Framework | ASP.NET Core 8 MVC (`net8.0`) |
| Language | C# |
| Front end | Razor views, Bootstrap 5, jQuery |
| HTTP client | `HttpClient` wrapped in a singleton `HttpService` |
| Serialization | Newtonsoft.Json |
| Weather data | OpenWeather Geocoding + Hourly Forecast APIs |
| Packaging | Docker |

## 📦 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) to run the app locally
- A free [OpenWeather account and API key](https://home.openweathermap.org/api_keys)
- An active internet connection
- Optional: [Docker](https://www.docker.com/products/docker-desktop) if you prefer containers

> **Note:** the hourly forecast endpoint (`pro.openweathermap.org/data/2.5/forecast/hourly`) is part of OpenWeather's paid plans. A free key can be used for the geocoding API, but hourly forecast data may require a subscription.

## 🔑 Configuration

The OpenWeather API key is **not** stored in the repository. It is read at runtime from the `OPENWEATHER_API_KEY` environment variable (see `Service/Config.cs`).

Linux / macOS:

```bash
export OPENWEATHER_API_KEY="your-openweather-api-key"
```

Windows (PowerShell):

```powershell
$env:OPENWEATHER_API_KEY="your-openweather-api-key"
```

If the variable is missing, requests to OpenWeather will fail with an authentication error.

## 🚀 Run Locally

```bash
git clone https://github.com/xBh4ne/easyWeather.git
cd easyWeather
export OPENWEATHER_API_KEY="your-openweather-api-key"
dotnet restore
dotnet run
```

Then open the URL printed in the console, by default:

- HTTP: <http://localhost:5042>
- HTTPS: <https://localhost:7142>

You can also open the solution in Visual Studio or JetBrains Rider and start one of the launch profiles defined in `Properties/launchSettings.json`.

## 🐳 Run with Docker

Pull and run the published image:

```bash
docker pull unicamjason/easyweather
docker run -d --name easyweather -p 8080:8080 \
  -e OPENWEATHER_API_KEY="your-openweather-api-key" \
  unicamjason/easyweather
```

Then open <http://localhost:8080>.

> The `Dockerfile` included in this repository targets **Windows containers** (`nanoserver-1809`) and is meant to be used with Visual Studio's container tooling on Windows. On Linux or macOS, use the published image above or adapt the Dockerfile to the Linux `aspnet`/`sdk` base images.

## 🌐 Endpoints

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/` | Search page with city autocomplete |
| `GET` | `/location/get?q={city}&limit=10` | JSON list of matching locations (geocoding) |
| `GET` | `/weather?latitude={lat}&longitude={lon}` | HTML hourly forecast page |
| `GET` | `/weather/get?latitude={lat}&longitude={lon}` | Hourly forecast as XML |

Example:

```bash
curl "http://localhost:5042/location/get?q=London&limit=5"
curl "http://localhost:5042/weather/get?latitude=51.5074&longitude=-0.1278"
```

Sample XML response (abridged):

```xml
<Forecast sunset="..." sunrise="...">
  <Location name="London" country="GB">
    <Coordinates longitude="-0.1278" latitude="51.5074" />
  </Location>
  <Weathers>
    <Weather deltaTime="..." description="light rain">
      <Wind speed="..." direction="..." gust="..." />
      <Cloud cloudiness="..." />
      <Temperature current="..." min="..." max="..." feelsLike="..." />
      <Humidity value="..." />
      <Visibility value="..." />
      <Precipitation percentege="..." rain1h="..." snow1h="..." />
    </Weather>
  </Weathers>
</Forecast>
```

## 📁 Project Structure

```text
EasyWeather/
├── Controllers/            # Home, Location and Weather MVC controllers
├── Enums/                  # Wind direction and speed unit enums
├── Models/                 # Domain models (Forecast, Weather, Wind, Temperature, Location)
├── Repository/             # Data access through the OpenWeather APIs
├── Service/
│   ├── Config.cs           # API key loaded from the environment
│   ├── HttpService.cs      # Singleton HTTP helper
│   ├── DTO/                # OpenWeather response DTOs
│   └── Mapper/             # DTO ↔ domain model mappers
├── Views/                  # Razor views (search page, forecast page, shared layout)
├── wwwroot/                # CSS, JavaScript, images, video backgrounds, Bootstrap/jQuery
├── Dockerfile
├── Program.cs
└── EasyWeather.csproj
```

## 📝 Notes

- The UI copy and the OpenWeather response language are currently Italian (`lang=it`); changing the language only requires updating the request parameter in `Service/HttpService.cs` and the view labels.
- `Program.cs` forces the `Development` environment, which is handy for local debugging but should be reviewed before a production deployment.
- The background videos live in `wwwroot/img/bg/` and are shared across all weather conditions at the moment.

## 🤝 Contributing

Issues and pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

Built with ❤️ using ASP.NET Core and the OpenWeather API.
