using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Misc.Seven.Domain;
using Nop.Web.Areas.Admin.Models.Customers;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.Seven.Models {
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

        [NopResourceDisplayName("Plugins.Misc.Seven.Message.To")]
        public List<string> To { get; set; } = new List<string>();

        [NopResourceDisplayName("Plugins.Misc.Seven.Message.Text")]
        public string Text { get; set; }

        [NopResourceDisplayName("Plugins.Misc.Seven.Message.From")]
        public string From { get; set; }

        public int ActiveStoreScopeConfiguration { get; set; }

        public IList<SelectListItem> AvailableCustomerRoles { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.Fields.CustomerRoles")]
        public IList<int> SelectedCustomerRoleIds { get; set; }

        public IList<AbstractMessageRecord> Sent { get; set; } = new List<AbstractMessageRecord>();
        
        #endregion
    }
}