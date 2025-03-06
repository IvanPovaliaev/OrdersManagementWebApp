using OrdersManagement.Domain.Contracts;
using System.Threading.Tasks;

namespace OrdersManagement.Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IOrdersRepository OrdersRepository { get; }

        private bool _canSaveChanges = true;

        public UnitOfWork(DatabaseContext databaseContext, IOrdersRepository ordersRepository)
        {
            _databaseContext = databaseContext;
            OrdersRepository = ordersRepository;
        }

        public async Task SaveChangesAsync()
        {
            if (!_canSaveChanges)
            {
                return;
            }
            await _databaseContext.SaveChangesAsync();
        }

        public void EnableSaveChanges()
        {
            _canSaveChanges = true;
        }

        public void DisableSaveChanges()
        {
            _canSaveChanges = false;
        }

        public bool CanSaveChanges()
        {
            return _canSaveChanges;
        }
    }
}
