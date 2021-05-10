using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tailwind.Ecommerce.CrossCutting.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
