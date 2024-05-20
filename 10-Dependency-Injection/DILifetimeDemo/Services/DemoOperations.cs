using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifetimeDemo.Services
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
    }
    public interface IOperationScoped : IOperation
    {
    }
    public interface IOperationSingleton : IOperation
    {
    }
    public interface IOperationInstance : IOperation
    {
    }

    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationInstance
    {
        private Guid _guid;

        public Operation(Guid? value = null)
        {
            _guid = value == null ? Guid.NewGuid() : value.Value;
        }

        public Guid OperationId
        {
            get
            {
                return _guid;
            }
        }
    }
}
