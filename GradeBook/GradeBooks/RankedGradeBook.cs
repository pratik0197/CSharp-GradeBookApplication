using System;
using System.Collections.Generic;
namespace GradeBook.GradeBooks{

    public class RankedGradeBook : BaseGradeBook{
        public RankedGradeBook(string name,bool isWeighted): base(name,isWeighted){
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException();
            
            List<double> grades = new List<double>();

            foreach(var student in Students){
                grades.Add(student.AverageGrade);
            }

            grades.Sort();
            grades.Reverse();

            int idx = grades.IndexOf(averageGrade);

            switch(idx){
                case var foundAt when foundAt < grades.Count/5:
                    return 'A';
                case var foundAt when foundAt < (2*grades.Count)/5:
                    return 'B';
                case var foundAt when foundAt < (3*grades.Count)/5:
                    return 'C';
                case var foundAt when foundAt < (4*grades.Count)/5:
                    return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5){
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5){
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            
            base.CalculateStudentStatistics(name);

        }
    }
}