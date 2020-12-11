using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Misc.Sms77.Domain;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>Represents abstract base message model</summary>
    public abstract class BaseAbstractMessageModel : BaseNopEntityModel {
        #region Ctor
        
        protected BaseAbstractMessageModel(string controllerName) {
            ControllerName = controllerName;

            var customerModel = new CustomerModel();
            SelectedCustomerRoleIds = customerModel.SelectedCustomerRoleIds;
            AvailableCustomerRoles = customerModel.AvailableCustomerRoles;
        }
        
        #endregion
        
        #region Properties

        public string ControllerName { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.Message.To")]
        public string To { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.Message.Text")]
        public string Text { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Sms77.Message.From")]
        public string From { get; set; }

        public int ActiveStoreScopeConfiguration { get; set; }

        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }

        public IList<AbstractMessageRecord> Sent { get; set; } = new List<AbstractMessageRecord>();
        
        #endregion
    }
}