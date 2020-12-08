using Nop.Web.Framework.Models.DataTables;

namespace Nop.Plugin.Misc.Sms77.Models.DataTables
{
    /// <summary>
    /// Represents button sms render for DataTables column
    /// </summary>
    public class RenderButtonSms : IRender
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the RenderButtonEdit class 
        /// </summary>
        /// <param name="url">URL to the edit action</param>
        public RenderButtonSms(DataUrl url)
        {
            Url = url;
            ClassName = NopButtonClassDefaults.Default;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Url to action edit
        /// </summary>
        public DataUrl Url { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }

        #endregion
    }
}