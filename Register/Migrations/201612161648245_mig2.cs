namespace Register.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        TeacherID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        GoodAnswer = c.String(),
                        BadAnswer = c.String(),
                        Points = c.Int(nullable: false),
                        Quiz_QuizID = c.Int(),
                        Teacher_TeacherID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Quizs", t => t.Quiz_QuizID)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherID)
                .Index(t => t.Quiz_QuizID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Timer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuizID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Teacher_TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Questions", "Quiz_QuizID", "dbo.Quizs");
            DropForeignKey("dbo.News", "TeacherID", "dbo.Teachers");
            DropIndex("dbo.Questions", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.Questions", new[] { "Quiz_QuizID" });
            DropIndex("dbo.News", new[] { "TeacherID" });
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.News");
        }
    }
}
