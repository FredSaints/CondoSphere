using CondoSphere.Core.DTOs.Financials;

namespace CondoSphere.Application.Services.Pdf
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> GenerateReceiptPdfAsync(ReceiptDto receiptDto)
        {
            var html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: sans-serif; }}
                        .receipt-container {{ border: 1px solid #ccc; padding: 20px; margin: 20px; }}
                        .header {{ text-align: center; border-bottom: 1px solid #ccc; padding-bottom: 10px; }}
                        .details {{ margin-top: 20px; }}
                        table {{ width: 100%; margin-top: 20px; border-collapse: collapse; }}
                        th, td {{ border: 1px solid #ddd; padding: 8px; }}
                        .total {{ font-weight: bold; }}
                    </style>
                </head>
                <body>
                    <div class='receipt-container'>
                        <div class='header'>
                            <h1>RECEIPT</h1>
                            <h2>{receiptDto.CompanyName}</h2>
                            <p>{receiptDto.CompanyAddress}<br/>Phone: {receiptDto.CompanyPhone}</p>
                        </div>
                        <div class='details'>
                            <p><strong>Receipt #:</strong> {receiptDto.Id}</p>
                            <p><strong>Date:</strong> {receiptDto.IssueDate:D}</p>
                            <hr/>
                            <p><strong>Billed To:</strong> {receiptDto.ResidentName}</p>
                            <p><strong>For:</strong> {receiptDto.CondominiumName} - Unit {receiptDto.UnitIdentifier}</p>
                        </div>
                        <table>
                            <thead>
                                <tr><th>Description</th><th style='text-align:right;'>Amount Paid</th></tr>
                            </thead>
                            <tbody>
                                <tr><td>{receiptDto.Details}</td><td style='text-align:right;'>{receiptDto.Amount:C}</td></tr>
                            </tbody>
                            <tfoot>
                                <tr class='total'><td>Total Paid</td><td style='text-align:right;'>{receiptDto.Amount:C}</td></tr>
                            </tfoot>
                        </table>
                    </div>
                </body>
                </html>";

            var renderer = new ChromePdfRenderer();
            var pdf = await renderer.RenderHtmlAsPdfAsync(html);
            return pdf.BinaryData;
        }
    }
}