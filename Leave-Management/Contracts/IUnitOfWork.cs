using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRespoistory<LeaveType> LeaveTypes { get;}
        IGenericRespoistory<LeaveRequest> LeaveRequests { get;}
        IGenericRespoistory<LeaveAllocation> LeaveAllocations { get;}
        Task Save();
    }
}
