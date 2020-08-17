namespace Steven.GoogleAuthenticator.WebForms.Migrations
{
    using Steven.GoogleAuthenticator.WebForms.Models;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGoogelAuthenticator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", nameof(ApplicationUser.IsGoogleAuthenticatorEnabled), c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", nameof(ApplicationUser.GoogleAuthenticatorSecretKey), c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", nameof(ApplicationUser.GoogleAuthenticatorSecretKey));
            DropColumn("dbo.AspNetUsers", nameof(ApplicationUser.IsGoogleAuthenticatorEnabled));
        }
    }
}
