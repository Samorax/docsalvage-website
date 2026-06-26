using Microsoft.AspNetCore.Mvc;

namespace DocSalvage.Controllers;

public class HomeController : Controller
{
    private record Meta(string Path, string Title, string Description);

    private const string BaseUrl = "https://docsalvage.cloud";

    // Per-route SEO metadata — keyword-rich titles & descriptions for each page.
    private static readonly Dictionary<string, Meta> Seo = new()
    {
        ["home"] = new Meta("/", "Doc-Salvage — AI Document Management Software for the Workplace | Store, Search, Process & Collaborate", "Doc-Salvage is AI document management software for the workplace. Store documents on Microsoft Azure, search by meaning, process invoices automatically, and collaborate in Microsoft 365 — pay-as-you-go from $22/TB and $1 per document."),
        ["capabilities"] = new Meta("/capabilities", "Document Management Capabilities — Cloud Storage, AI Search, Invoice Processing & Collaboration | Doc-Salvage", "Explore Doc-Salvage capabilities: elastic Azure cloud document storage, AI semantic search across scans, PDFs and Office files, automated invoice processing, and Microsoft 365 collaboration — the full document lifecycle in one system."),
        ["bookkeeping"] = new Meta("/bookkeeping", "Automated Invoice Processing & Bookkeeping Software | OCR Data Extraction & Bank Reconciliation — Doc-Salvage", "Turn invoices and receipts into ledger entries automatically. Doc-Salvage captures documents, extracts data with AI, posts payables and receivables to your accounting system, and reconciles against bank statements with a full audit trail."),
        ["pricing"] = new Meta("/pricing", "Doc-Salvage Pricing — Pay-As-You-Go Document Management | $22/TB Storage, Free Search, $1 Invoice Processing", "Simple, transparent pay-as-you-go pricing with no subscriptions or lock-in. Storage at $22 per TB per month, free AI search, and $1 per document processed. Pay only for what you use, billed per company account."),
        ["security"] = new Meta("/security", "Security & Compliance — Microsoft Azure, Entra SSO & M365 Permissions | Doc-Salvage", "Doc-Salvage keeps documents inside your own Microsoft Azure tenant with data residency you control, Microsoft Entra single sign-on, M365-based access control, automatic redundancy, and complete audit trails on every document."),
        ["download"] = new Meta("/download", "Download Doc-Salvage for Windows — AI Document Management App | Doc-Salvage", "Download Doc-Salvage for Windows 10 and 11 and start managing documents with AI storage, search and invoice processing. macOS coming soon. Free to install — pay only for what you use."),
        ["docs"] = new Meta("/docs", "Installation Guide & Documentation — Setup in Minutes | Doc-Salvage", "Step-by-step installation guide and documentation for Doc-Salvage. Install on Windows, connect your Microsoft Azure and 365 tenant, and start storing, searching and processing documents in minutes."),
    };

    private IActionResult Page(string key, string view)
    {
        var m = Seo[key];
        ViewData["Title"] = m.Title;
        ViewData["Description"] = m.Description;
        ViewData["Canonical"] = BaseUrl + m.Path;
        return View(view);
    }

    [Route("/")] public IActionResult Index() => Page("home", "Index");
    [Route("capabilities")] public IActionResult Capabilities() => Page("capabilities", "Capabilities");
    [Route("bookkeeping")] public IActionResult Bookkeeping() => Page("bookkeeping", "Bookkeeping");
    [Route("pricing")] public IActionResult Pricing() => Page("pricing", "Pricing");
    [Route("security")] public IActionResult Security() => Page("security", "Security");
    [Route("download")] public IActionResult Download() => Page("download", "Download");
    [Route("docs")] public IActionResult Docs() => Page("docs", "Docs");
}
