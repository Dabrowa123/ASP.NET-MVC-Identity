namespace Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationsUserClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationsUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        InformationsUserId = c.Int(nullable: false),
                        Name = c.String(),
                        Forename = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "InformationsUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "InformationsUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "InformationsUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "InformationsUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserRoles", "InformationsUser_Id");
            CreateIndex("dbo.AspNetUsers", "InformationsUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "InformationsUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "InformationsUser_Id");
            AddForeignKey("dbo.AspNetUserClaims", "InformationsUser_Id", "dbo.InformationsUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "InformationsUser_Id", "dbo.InformationsUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "InformationsUser_Id", "dbo.InformationsUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "InformationsUser_Id", "dbo.InformationsUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Forename");
            DropColumn("dbo.AspNetUsers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Forename", c => c.String());
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "InformationsUser_Id", "dbo.InformationsUsers");
            DropForeignKey("dbo.AspNetUserRoles", "InformationsUser_Id", "dbo.InformationsUsers");
            DropForeignKey("dbo.AspNetUserLogins", "InformationsUser_Id", "dbo.InformationsUsers");
            DropForeignKey("dbo.AspNetUserClaims", "InformationsUser_Id", "dbo.InformationsUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "InformationsUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "InformationsUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "InformationsUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "InformationsUser_Id" });
            DropColumn("dbo.AspNetUserLogins", "InformationsUser_Id");
            DropColumn("dbo.AspNetUserClaims", "InformationsUser_Id");
            DropColumn("dbo.AspNetUsers", "InformationsUser_Id");
            DropColumn("dbo.AspNetUserRoles", "InformationsUser_Id");
            DropTable("dbo.InformationsUsers");
        }
    }
}
