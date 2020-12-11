using FluentMigrator.Builders.Create.Table;
using Nop.Core;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Data {
    /// <summary>Represents an abstract message entity builder</summary>
    public abstract class AbstractMessageRecordBuilder<T> : NopEntityBuilder<T> where T : BaseEntity {
        #region Methods

        /// <summary>Apply entity configuration</summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table) {
            table
                .WithColumn(nameof(SmsRecord.Config)).AsString(int.MaxValue).NotNullable();
        }
        
        #endregion
    }
}