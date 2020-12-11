using FluentMigrator.Builders.Create.Table;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Data {
    /// <summary>Represents a sms entity builder</summary>
    public partial class SmsRecordBuilder : AbstractMessageRecordBuilder<SmsRecord> {
        #region Methods

        /// <inheritdoc />
        public override void MapEntity(CreateTableExpressionBuilder table) {
            table
                .WithColumn(nameof(SmsRecord.Response)).AsString(int.MaxValue).Nullable()
                ;

            base.MapEntity(table);
        }

        #endregion
    }
}