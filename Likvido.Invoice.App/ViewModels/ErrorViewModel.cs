using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likvido.Invoice.App.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorType ErrorType { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }

    public enum ErrorType
    {
        API,
        Application
    }
}
