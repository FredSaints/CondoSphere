namespace CondoSphere.Application.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICompanyRepository Companies { get; }
        IUserRepository Users { get; }
        ICondominiumRepository Condominiums { get; }
        IUnitRepository Units { get; }
        IOccurrenceRepository Occurrences { get; }
        IInterventionRepository Interventions { get; }
        IExpenseRepository Expenses { get; }
        IUnitQuotaRepository UnitQuotas { get; }
        IQuotaPaymentRepository QuotaPayments { get; }
        IReceiptRepository Receipts { get; }
        IDocumentRepository Documents { get; }


        IAssemblyRepository Assemblies { get; }
        IAssemblyInviteRepository AssemblyInvites { get; }
        IAssemblyMessageRepository AssemblyMessages { get; }
        IAssemblyParticipantRepository AssemblyParticipants { get; }

        Task<int> CompleteAsync();

    }
}
