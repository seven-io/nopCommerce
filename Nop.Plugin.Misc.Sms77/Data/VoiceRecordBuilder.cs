using FluentMigrator.Builders.Create.Table;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Data {
    /// <summary>Represents a voice entity builder</summary>
    public partial class VoiceRecordBuilder : AbstractMessageRecordBuilder<VoiceRecord> {
        #region Methods

        /// <inheritdoc />
        public override void MapEntity(CreateTableExpressionBuilder table) {
            table
                .WithColumn(nameof(VoiceRecord.Code)).AsInt16().Nullable()
                .WithColumn(nameof(VoiceRecord.Cost)).AsDouble().Nullable()
                .WithColumn(nameof(VoiceRecord.Sms77Id)).AsInt32().Nullable()
                ;

            base.MapEntity(table);
        }

        #endregion
    }
}