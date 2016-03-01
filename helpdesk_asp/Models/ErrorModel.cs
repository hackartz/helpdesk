using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helpdesk_asp.Models
{
    public class ErrorModel
    {
        public string ErrorCode { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorDescription { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Exception ex { get; set; }
    }
}