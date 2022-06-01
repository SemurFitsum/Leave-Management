using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRespoistory<LeaveType> _leaveTypes;
        private IGenericRespoistory<LeaveRequest> _leaveRequests;
        private IGenericRespoistory<LeaveAllocation> _leaveAllocations;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRespoistory<LeaveType> LeaveTypes  
            => _leaveTypes ??= new GenericRepository<LeaveType>(_context);

        public IGenericRespoistory<LeaveRequest> LeaveRequests
            => _leaveRequests ??= new GenericRepository<LeaveRequest>(_context);

        public IGenericRespoistory<LeaveAllocation> LeaveAllocations
            => _leaveAllocations ??= new GenericRepository<LeaveAllocation>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
