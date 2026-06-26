# Doc-Salvage — ASP.NET Core MVC

A faithful ASP.NET Core 8 MVC port of the Doc-Salvage marketing site. Each page is a
server-rendered Razor View sharing one layout; routing is real server-side navigation.

## Run

```bash
cd DocSalvage
dotnet run
```

Then open the printed `https://localhost:xxxx` URL.

## Routes

| URL | Action | View |
|-----|--------|------|
| `/` | `Index` | `Views/Home/Index.cshtml` |
| `/capabilities` | `Capabilities` | `Capabilities.cshtml` |
| `/bookkeeping` | `Bookkeeping` | `Bookkeeping.cshtml` |
| `/pricing` | `Pricing` | `Pricing.cshtml` |
| `/security` | `Security` | `Security.cshtml` |
| `/download` | `Download` | `Download.cshtml` |
| `/docs` | `Docs` | `Docs.cshtml` |

## Structure

- **Views/Shared/_Layout.cshtml** — `<head>` (SEO meta, JSON-LD, fonts), the announcement
  bar, sticky nav, `@RenderBody()`, and the footer.
- **Controllers/HomeController.cs** — one action per page; sets per-route `Title`,
  `Description` and canonical URL via `ViewData`, which the layout renders into the
  `<title>`, meta description, canonical link and Open Graph / Twitter tags.
- **wwwroot/css/site.css** — font + reset rules and the keyframe animations.
- **wwwroot/js/site.js** — hover effects (ported from the original `style-hover`
  attributes, now `data-hover`) and the live pricing calculator.
- **wwwroot/assets/** — logo, favicon and OG image.
- **wwwroot/robots.txt**, **wwwroot/sitemap.xml** — served at the site root.

## Notes

- All styling stays inline on the elements (as in the source), so there is no component
  CSS framework to learn — edit markup directly in the Views.
- Replace `https://docsalvage.cloud` in `_Layout.cshtml`, `HomeController.cs`,
  `robots.txt` and `sitemap.xml` if the production domain changes.
- The JSON-LD graph and keyword meta are site-wide and live in the layout.
