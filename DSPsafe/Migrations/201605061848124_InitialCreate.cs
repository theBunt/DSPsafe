namespace DSPsafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incident",
                c => new
                    {
                        IncidentId = c.Int(nullable: false, identity: true),
                        TypeOfIncident = c.String(),
                        StaffIncident = c.Boolean(nullable: false),
                        HomeVisitIncident = c.Boolean(nullable: false),
                        BriefDesc = c.String(),
                        DateOccurred = c.DateTime(nullable: false),
                        StaffId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IncidentId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Staff", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Email = c.String(),
                        EmpType = c.String(),
                        Phone = c.String(),
                        ManagerId = c.Int(nullable: false),
                        SafetyRole = c.String(),
                        Area = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Region = c.String(),
                        Building = c.String(),
                        Employees_StaffId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Staff", t => t.Employees_StaffId)
                .Index(t => t.Employees_StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incident", "StaffId", "dbo.Staff");
            DropForeignKey("dbo.Incident", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Location", "Employees_StaffId", "dbo.Staff");
            DropIndex("dbo.Location", new[] { "Employees_StaffId" });
            DropIndex("dbo.Incident", new[] { "LocationId" });
            DropIndex("dbo.Incident", new[] { "StaffId" });
            DropTable("dbo.Location");
            DropTable("dbo.Staff");
            DropTable("dbo.Incident");
        }
    }
}
