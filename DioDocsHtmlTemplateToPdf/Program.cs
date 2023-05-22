// See https://aka.ms/new-console-template for more information
using DioDocsHtmlTemplateToPdf;

Console.WriteLine("HTMLテンプレートを利用してPDF帳票を作成");

var invoiceBuilder = new InvoiceBuilder();
invoiceBuilder.CreatePDF();