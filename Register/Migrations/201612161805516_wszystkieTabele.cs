namespace Register.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wszystkieTabele : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Quiz_QuizID", "dbo.Quizs");
            DropIndex("dbo.Questions", new[] { "Quiz_QuizID" });
            RenameColumn(table: "dbo.Questions", name: "Teacher_TeacherID", newName: "TeacherID");
            RenameColumn(table: "dbo.Questions", name: "Quiz_QuizID", newName: "QuizID");
            RenameIndex(table: "dbo.Questions", name: "IX_Teacher_TeacherID", newName: "IX_TeacherID");
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Weight = c.Int(nullable: false),
                        DateGrade = c.DateTime(nullable: false),
                        MySubjectID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        GradeListID = c.Int(nullable: false),
                        Student_StudentID = c.String(maxLength: 128),
                        Teacher_TeacherID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.GradeID)
                .ForeignKey("dbo.GradeLists", t => t.GradeListID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherID)
                .Index(t => t.GradeListID)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Teacher_TeacherID);
            
            CreateTable(
                "dbo.GradeLists",
                c => new
                    {
                        GradeListID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradeListID);
            
            CreateTable(
                "dbo.MySubjects",
                c => new
                    {
                        MySubjectID = c.Int(nullable: false, identity: true),
                        TeacherID = c.String(maxLength: 128),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MySubjectID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.TeacherID)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MySubjectID = c.Int(nullable: false),
                        SClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.SClasses",
                c => new
                    {
                        SClassID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        TeacherID = c.String(),
                    })
                .PrimaryKey(t => t.SClassID)
                .ForeignKey("dbo.Teachers", t => t.SClassID)
                .Index(t => t.SClassID);
            
            CreateTable(
                "dbo.SClassSubjects",
                c => new
                    {
                        SClass_SClassID = c.String(nullable: false, maxLength: 128),
                        Subject_SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SClass_SClassID, t.Subject_SubjectID })
                .ForeignKey("dbo.SClasses", t => t.SClass_SClassID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectID, cascadeDelete: true)
                .Index(t => t.SClass_SClassID)
                .Index(t => t.Subject_SubjectID);
            
            AddColumn("dbo.Students", "SClassID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "SClass_SClassID", c => c.String(maxLength: 128));
            AddColumn("dbo.Teachers", "SClassID", c => c.Int());
            AlterColumn("dbo.Questions", "QuizID", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "SClass_SClassID");
            CreateIndex("dbo.Questions", "QuizID");
            AddForeignKey("dbo.Students", "SClass_SClassID", "dbo.SClasses", "SClassID");
            AddForeignKey("dbo.Questions", "QuizID", "dbo.Quizs", "QuizID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuizID", "dbo.Quizs");
            DropForeignKey("dbo.MySubjects", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.MySubjects", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.SClasses", "SClassID", "dbo.Teachers");
            DropForeignKey("dbo.SClassSubjects", "Subject_SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.SClassSubjects", "SClass_SClassID", "dbo.SClasses");
            DropForeignKey("dbo.Students", "SClass_SClassID", "dbo.SClasses");
            DropForeignKey("dbo.Grades", "Teacher_TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Grades", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Grades", "GradeListID", "dbo.GradeLists");
            DropIndex("dbo.SClassSubjects", new[] { "Subject_SubjectID" });
            DropIndex("dbo.SClassSubjects", new[] { "SClass_SClassID" });
            DropIndex("dbo.Questions", new[] { "QuizID" });
            DropIndex("dbo.SClasses", new[] { "SClassID" });
            DropIndex("dbo.MySubjects", new[] { "SubjectID" });
            DropIndex("dbo.MySubjects", new[] { "TeacherID" });
            DropIndex("dbo.Grades", new[] { "Teacher_TeacherID" });
            DropIndex("dbo.Grades", new[] { "Student_StudentID" });
            DropIndex("dbo.Grades", new[] { "GradeListID" });
            DropIndex("dbo.Students", new[] { "SClass_SClassID" });
            AlterColumn("dbo.Questions", "QuizID", c => c.Int());
            DropColumn("dbo.Teachers", "SClassID");
            DropColumn("dbo.Students", "SClass_SClassID");
            DropColumn("dbo.Students", "SClassID");
            DropTable("dbo.SClassSubjects");
            DropTable("dbo.SClasses");
            DropTable("dbo.Subjects");
            DropTable("dbo.MySubjects");
            DropTable("dbo.GradeLists");
            DropTable("dbo.Grades");
            RenameIndex(table: "dbo.Questions", name: "IX_TeacherID", newName: "IX_Teacher_TeacherID");
            RenameColumn(table: "dbo.Questions", name: "QuizID", newName: "Quiz_QuizID");
            RenameColumn(table: "dbo.Questions", name: "TeacherID", newName: "Teacher_TeacherID");
            CreateIndex("dbo.Questions", "Quiz_QuizID");
            AddForeignKey("dbo.Questions", "Quiz_QuizID", "dbo.Quizs", "QuizID");
        }
    }
}
