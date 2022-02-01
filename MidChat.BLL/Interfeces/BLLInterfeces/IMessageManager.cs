using MidChat.BLL.Models;
using MidChat.BLL.ResultModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces.BLLInterfeces
{
    public interface IMessageManager
    {
        Task<MessegeItemResult> MessegeItemAsync(MessegeItemModel commentItemModel);
    }
}
