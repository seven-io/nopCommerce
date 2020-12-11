using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.Sms77.Domain;

namespace Nop.Plugin.Misc.Sms77.Data {
    [SkipMigrationOnUpdate]
    [NopMigration("2020/12/11 10:29:55:1687541", "Misc.Sms77 Schemas")]
    public class SchemaMigration : AutoReversingMigration {
        private readonly IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager) {
            _migrationManager = migrationManager;
        }

        public override void Up() {
            _migrationManager.BuildTable<SmsRecord>(Create);

            _migrationManager.BuildTable<VoiceRecord>(Create);
        }
    }
}