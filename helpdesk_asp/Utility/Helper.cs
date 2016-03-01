using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Reflection;
using System.Web.Mvc;
using helpdesk_asp.Models;

namespace startup_emr.Utility
{
    public static class Helper
    {
        public static FormsAuthenticationTicket GetTicket(HttpRequestBase request)
        { 
            HttpCookie authCookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return null;
            }
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            if (ticket == null)
            {
                return null;
            }

            return ticket;
        }

        public static string GetErrorView()
        {
           
            return "~/Views/Error.cshtml";
           
        }

        public static ErrorModel GetErrorModel(Exception ex, HttpRequestBase request)
        {

            try
            {
                string type = ex.Message.ToString();
                string ErrorCode = string.Empty;
                if(type == "Bad Request")
                {
                    ErrorCode = "400";
                }

                ErrorModel mod = new ErrorModel();
                mod.ex = ex;
                mod.ErrorCode = ErrorCode;
                mod.ErrorTitle = "Error Occured";
                mod.ErrorDescription = "Silahkan hubungi SIRS";
                mod.Area = GetAreaName(request);
                mod.Controller = GetControllerName(request);
                mod.Action = GetActionName(request);
                return mod;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetAreaName(HttpRequestBase httpContext)
        {
            string area = string.Empty;
            area = httpContext.RequestContext.RouteData.DataTokens.ContainsKey("area") ? httpContext.RequestContext.RouteData.DataTokens["area"].ToString() : "";
            return area;
        }

        public static string GetControllerName(HttpRequestBase httpContext)
        {
            string controller = string.Empty;
            controller = httpContext.RequestContext.RouteData.Values["controller"].ToString();
            return controller;
        }

        public static string GetActionName(HttpRequestBase httpContext)
        {
            string action = string.Empty;
            action = httpContext.RequestContext.RouteData.Values["action"].ToString();
            return action;
        }

        
    }

}