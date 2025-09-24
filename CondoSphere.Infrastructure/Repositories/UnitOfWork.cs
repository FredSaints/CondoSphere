using CondoSphere.Application.Interfaces;
using CondoSphere.Infrastructure.Data;
using System.Threading.Tasks;

namespace CondoSphere.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _userContext;
        private readonly CondominiumDbContext _condoContext;
        private readonly FinancialsDbContext _financialsContext;

        public ICompanyRepository Companies { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICondominiumRepository Condominiums { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IOccurrenceRepository Occurrences { get; private set; }
        public IInterventionRepository Interventions { get; private set; }
        public IExpenseRepository Expenses { get; private set; }
        public IUnitQuotaRepository UnitQuotas { get; private set; }
        public IQuotaPaymentRepository QuotaPayments { get; private set; }
        public IReceiptRepository Receipts { get; private set; }
        public IDocumentRepository Documents { get; private set; }
        public IAssemblyRepository Assemblies { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IMessageRepository Messages { get; private set; }
        public IAssemblyInviteRepository AssemblyInvites { get; private set; }
        public IAssemblyParticipantRepository AssemblyParticipants { get; private set; }

        public UnitOfWork(UserManagementDbContext userContext, CondominiumDbContext condoContext, FinancialsDbContext financialsContext)
        {
            _userContext = userContext;
            _condoContext = condoContext;
            _financialsContext = financialsContext;

            Companies = new CompanyRepository(_userContext);
            Users = new UserRepository(_userContext);
            Condominiums = new CondominiumRepository(_condoContext);
            Units = new UnitRepository(_condoContext);
            Occurrences = new OccurrenceRepository(_condoContext);
            Interventions = new InterventionRepository(_condoContext);
            Expenses = new ExpenseRepository(_financialsContext);
            UnitQuotas = new UnitQuotaRepository(_financialsContext);
            QuotaPayments = new QuotaPaymentRepository(_financialsContext);
            Receipts = new ReceiptRepository(_financialsContext);
            Documents = new DocumentRepository(_condoContext);
            Notifications = new NotificationRepository(_userContext);
            Messages = new MessageRepository(_userContext);
            Assemblies = new AssemblyRepository(_condoContext);
            AssemblyInvites = new AssemblyInviteRepository(_condoContext);
            AssemblyParticipants = new AssemblyParticipantRepository(_condoContext);
        }

        public async Task<int> CompleteAsync()
        {
            var userDbResult = await _userContext.SaveChangesAsync();
            var condoDbResult = await _condoContext.SaveChangesAsync();
            var financialsDbResult = await _financialsContext.SaveChangesAsync();
            return userDbResult + condoDbResult + financialsDbResult;
        }

        public async ValueTask DisposeAsync()
        {
            await _userContext.DisposeAsync();
            await _condoContext.DisposeAsync();
            await _financialsContext.DisposeAsync();
        }
    }
}