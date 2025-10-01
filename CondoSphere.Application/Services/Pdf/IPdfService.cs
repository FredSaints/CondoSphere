using CondoSphere.Core.DTOs.Financials;

namespace CondoSphere.Application.Services.Pdf
{
    /// <summary>
    /// I Pdf Service.
    /// </summary>
    public interface IPdfService
    {
        Task<byte[]> GenerateReceiptPdfAsync(ReceiptDto receiptDto);
    }
}