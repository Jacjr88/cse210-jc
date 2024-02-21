using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello FinalProject World!");

        Student student = new Student("Javi",9,"Alte Brown 2733", "15151515", "javito@hotmail.com");

        Student student2 = new Student("Pedro",15,"Alte Brown 2121", "351355555", "pedrito@hotmail.com");

        Instructor instructor = new Instructor("Jose", 43, "Delili 1515", "351351", "dasdljk@hotmai.com", 0);
        Instructor instructor2 = new Instructor("Nahuel", 43, "Delili 1515", "351351", "dasdljk@hotmai.com", 0);

        OnlineCourse course = new OnlineCourse("Data Science", 3, 1550, instructor, "asdas.com");
        OnlineCourse course2 = new OnlineCourse("Data Analyst", 3, 1550, instructor2, "asdas.com");

        student.AddCreditToBalance(4000);
        student2.AddCreditToBalance(4000);

        student.EnrollCourse(course,student.GetBalance());
        student.EnrollCourse(course2,student.GetBalance());
        student2.EnrollCourse(course,student2.GetBalance());

        Homework homework = new Homework("Read text", course, new DateTime(2024, 2, 15));

        Console.WriteLine("Student1 assignments en homework 1");
        foreach(Assignment assignment in student.GetAssignments()){
            Console.WriteLine($"{assignment.GetId()} {assignment.GetName()}");
        }
        Console.WriteLine("Student2 assignments en homework 1");
        foreach(Assignment assignment in student2.GetAssignments()){
            Console.WriteLine($"{assignment.GetId()} {assignment.GetName()}");
        }
        Homework homework2 = new Homework("Make draw", course2, new DateTime(2024, 2, 15));

        Console.WriteLine("Student1 assignments en homework 2");
        foreach(Assignment assignment in student.GetAssignments()){
            Console.WriteLine($"{assignment.GetId()} {assignment.GetName()}");
        }
        Console.WriteLine("Student2 assignments en homework 2");
        foreach(Assignment assignment in student2.GetAssignments()){
            Console.WriteLine($"{assignment.GetId()} {assignment.GetName()}");
        }

        StudentGrades studentGrades = new StudentGrades(student, homework, 25);

        /*course.AddAssignment(homework);
        
        course2.AddAssignment(homework2);*/

        //student.AddAbsence();

        //student.DisplayCourses();

        instructor.GradeAssignment(student, homework, 80);

        instructor.GradeAssignment(student, homework2, 90);

        Console.WriteLine($"El estudiante esta aprobado: {student.IsApproved()}");

        Console.WriteLine("Students");
        Console.WriteLine(student.GetStringRepresentation());
        Console.WriteLine(student2.GetStringRepresentation());
        Console.WriteLine("Instructors");
        Console.WriteLine(instructor.GetStringRepresentation());
        Console.WriteLine(instructor2.GetStringRepresentation());
        Console.WriteLine("Assignments");
        Console.WriteLine(homework.GetStringRepresentation());

        course.DisplayEnrolledStudents().ForEach(Console.WriteLine);

    }
}