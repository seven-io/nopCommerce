using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.Seven.Domain;

namespace Nop.Plugin.Misc.Seven.Data {
    [SkipMigrationOnUpdate]
    [NopMigration("2020/12/11 10:29:55:1687541", "Misc.Seven Schemas")]
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