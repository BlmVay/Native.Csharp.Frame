using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;

namespace Native.Csharp.App.Event
{
    public class Event_ExecutiveOrder : IBlmExecutiveOrder
    {
        public bool Executive(object o, BlmOrderArgs e)
        {
            switch (blmOrderArgs.orderType)
            {
                case BlmOrderArgsBase.OrderType.AddMaster:
                    GlobalVariable.Masters.Add(e.)
                    break;
                case BlmOrderArgsBase.OrderType.RemoveMaster: break;
                case BlmOrderArgsBase.OrderType.SetMainMaster: break;
                case BlmOrderArgsBase.OrderType.SetSendMessageQueueIntervalTime: break;
                case BlmOrderArgsBase.OrderType.SetState: break;
            }
            return false;
        }
    }
}
