using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Data {
    /// <summary>
    /// Represents a setting entity builder
    /// </summary>
    public partial class SmsRecordBuilder : NopEntityBuilder<SmsRecord> {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table) {
            table
                .WithColumn(nameof(SmsRecord.Config)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(SmsRecord.Response)).AsString(int.MaxValue).Nullable();
        }

        #endregion
    }
}