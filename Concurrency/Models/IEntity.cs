using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency.Models
{
    public interface IEntity : IEntity<int>
    {

    }

    public interface IEntity<T>
    {
        T Id { get; set; }

        string RowIdentifier { get; set; }

        int? IsDeleted { get; set; }
    }
}
