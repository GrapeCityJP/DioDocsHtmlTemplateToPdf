using DioDocsHtmlTemplateToPdf.Model;
using GrapeCity.Documents.Html;
using Scriban;
using System.Text.Json;

namespace DioDocsHtmlTemplateToPdf
{
    public class InvoiceBuilder
    {
        public void CreatePDF()
        {
            // 請求書に追加するデータ
            var invoice = JsonSerializer.Deserialize<Invoice>(File.ReadAllText("InvoiceData.json"));
            var templateData = new { invoice };

            // HTMLテンプレートを読み込み
            var invoiceTemplate = File.ReadAllText("./Template/InvoiceTemplate.html");
            var template = Template.Parse(invoiceTemplate);
            
            // HTMLテンプレートにデータを追加
            var pageContent = template.Render(templateData);
            File.WriteAllText("./Template/pageContent.html", pageContent, System.Text.Encoding.UTF8);

            // HTMLのレンダリングに使用するGcHtmlBrowserのインスタンスを生成
            var browserPath = BrowserFetcher.GetSystemChromePath();
            using var browser = new GcHtmlBrowser(browserPath);

            // HTMLをレンダリング
            var uri = new Uri("./Template/pageContent.html", UriKind.Relative);
            using var htmlPage = browser.NewPage(uri);

            // PDFとして保存
            htmlPage.SaveAsPdf("InvoiceResult.pdf");
        }
    }
}
