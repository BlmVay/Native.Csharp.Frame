using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.EventArgs;
namespace Native.Csharp.App.Interface
{
    public interface IBlmExecutiveOrder
    {
        bool Executive(object o, BlmOrderArgs blmOrderArgs);
    }
}
