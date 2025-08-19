using CondoSphere.Core.DTOs.Financials;

namespace CondoSphere.Application.Services.Pdf
{
    public interface IPdfService
    {
        Task<byte[]> GenerateReceiptPdfAsync(ReceiptDto receiptDto);
    }
}