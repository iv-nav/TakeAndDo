namespace TakeAndDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "sheldoncooper.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "sheldoncooper.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("sheldoncooper.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("sheldoncooper.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "sheldoncooper.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "sheldoncooper.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sheldoncooper.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "sheldoncooper.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("sheldoncooper.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "sheldoncooper.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("sheldoncooper.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("sheldoncooper.AspNetUsers", "Id", "sheldoncooper.Users");
            DropForeignKey("sheldoncooper.UserRoles", "IdentityUser_Id", "sheldoncooper.Users");
            DropForeignKey("sheldoncooper.UserLogins", "IdentityUser_Id", "sheldoncooper.Users");
            DropForeignKey("sheldoncooper.UserClaims", "IdentityUser_Id", "sheldoncooper.Users");
            DropForeignKey("sheldoncooper.UserRoles", "RoleId", "sheldoncooper.Roles");
            DropIndex("sheldoncooper.AspNetUsers", new[] { "Id" });
            DropIndex("sheldoncooper.UserLogins", new[] { "IdentityUser_Id" });
            DropIndex("sheldoncooper.UserClaims", new[] { "IdentityUser_Id" });
            DropIndex("sheldoncooper.Users", "UserNameIndex");
            DropIndex("sheldoncooper.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("sheldoncooper.UserRoles", new[] { "RoleId" });
            DropIndex("sheldoncooper.Roles", "RoleNameIndex");
            DropTable("sheldoncooper.AspNetUsers");
            DropTable("sheldoncooper.UserLogins");
            DropTable("sheldoncooper.UserClaims");
            DropTable("sheldoncooper.Users");
            DropTable("sheldoncooper.UserRoles");
            DropTable("sheldoncooper.Roles");
        }
    }
}
