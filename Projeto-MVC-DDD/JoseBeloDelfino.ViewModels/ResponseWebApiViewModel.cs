using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseBeloDelfino.ViewModels
{
    public class ResponseWebApiViewModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public static class Retorno
    {
        public static ResponseWebApiViewModel WebApi = new ResponseWebApiViewModel();
    }

}
