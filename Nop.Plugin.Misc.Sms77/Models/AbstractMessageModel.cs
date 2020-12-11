namespace Nop.Plugin.Misc.Sms77.Models {
    /// <summary>
    /// Represents abstract message model
    /// </summary>
    public abstract class AbstractMessageModel : MessageModel {
        #region Ctor

        protected AbstractMessageModel(string controllerName) {
            ControllerName = controllerName;
        }

        #endregion

        #region Properties

        public readonly string ControllerName;

        #endregion
    }
}