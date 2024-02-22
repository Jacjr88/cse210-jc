using System.Dynamic;

class MainMenu {

    List<Person> _persons;

    List<Course> _courses;


    public List<Person> GetPersons(){
        return _persons;
    }

    public void SetPersons(List<Person> persons){
        _persons = persons;
    }

    public List<Course> GetCourses(){
        return _courses;
    }

    public void SetCourses(List<Course> courses){
        _courses = courses;
    }

    public MainMenu(){
        //LoadData();
    }

    public void LoadData(){
        SetPersons(LoadPersons());
    }

    public void Run(){
        int optionInput = 0;
        while (optionInput != 6){

            DisplayMenu();
            optionInput = int.Parse(Console.ReadLine());

            if (optionInput == 1){
                
                CreateNewStudent();
                
            } else if (optionInput == 2){
                
                CreateNewInstructor();

            } else if (optionInput == 3){

                CreateNewCourse();

            } else if (optionInput == 4){

                StudentMenu();
                
            } /*else if (optionInput == 5){

                RecordEvent();
                
            }*/
        }

    }

    public void DisplayMenu(){
        Console.Clear();
        Console.WriteLine("Main Menu:");
        Console.Write("  1- Create new Student\n  2- Create new Instructor\n  3- Create Course\n  4- Student Menu\n  5- Instructor Menu\n  6- Quit\nSelect a choice from the menu: ");
        
    }

    public void CreateNewStudent(){

        Console.Write("What is the student name? ");
        string studentName = Console.ReadLine();
        Console.Write("What is the student age? ");
        int studentAge = int.Parse(Console.ReadLine());
        Console.Write("What is the student address? ");
        string studentAddress = Console.ReadLine();
        Console.Write("What is the student phone? ");
        string studentPhone = Console.ReadLine();
        Console.Write("What is the student email? ");
        string studentEmail = Console.ReadLine();

        Student student = new Student(studentName, studentAge, studentAddress, studentPhone, studentEmail);
        student.SavePerson();

        Console.WriteLine($"Student created \n {student.DisplayPersonData()}");
        Thread.Sleep(3000);

    }

    public void CreateNewInstructor(){

        Console.Write("What is the instructor name? ");
        string instructorName = Console.ReadLine();
        Console.Write("What is the instructor age? ");
        int instructorAge = int.Parse(Console.ReadLine());
        Console.Write("What is the instructor address? ");
        string instructorAddress = Console.ReadLine();
        Console.Write("What is the instructor phone? ");
        string instructorPhone = Console.ReadLine();
        Console.Write("What is the instructor email? ");
        string instructorEmail = Console.ReadLine();

        Instructor instructor = new Instructor(instructorName, instructorAge, instructorAddress, instructorPhone, instructorEmail);
        instructor.SavePerson();

        Console.WriteLine($"Instructor created \n {instructor.DisplayPersonData()}");
        Thread.Sleep(3000);

    }

    public void CreateNewCourse(){
        Console.Clear();
        Console.WriteLine("Course Creation Menu:");
        Console.WriteLine("Which kind of Course you want to create: \n  1- Online Course\n  2- Classroom Course");
        int courseType = int.Parse(Console.ReadLine());

        if (courseType == 1){
            Console.WriteLine("What is the Course name? ");
            string courseName = Console.ReadLine();
            Console.WriteLine("What is the course duration (Months)? ");
            int courseDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the course cost? ");
            int courseCost = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the course Instructor? (ID)");
            LoadInstructors().ForEach(instructor => Console.WriteLine(instructor.DisplayPersonData()));
            int instructorId = int.Parse(Console.ReadLine());
            Instructor instructor = GetInstructorById(LoadInstructors(), instructorId);
            Console.WriteLine("What is the course Web Platform?");
            string courseWebPlatform = Console.ReadLine();
            OnlineCourse onlineCourse = new OnlineCourse(courseName, courseDuration, courseCost, instructor, courseWebPlatform);
            onlineCourse.SaveCourse();
            
            Console.WriteLine($"Course created \n {onlineCourse.GetStringRepresentation()}");

        }

        if (courseType == 2){
            Console.WriteLine("What is the Course name? ");
            string courseName = Console.ReadLine();
            Console.WriteLine("What is the course duration (Months)? ");
            int courseDuration = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the course cost? ");
            int courseCost = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the course Instructor? (ID)");
            LoadInstructors().ForEach(instructor => Console.WriteLine(instructor.DisplayPersonData()));
            int instructorId = int.Parse(Console.ReadLine());
            Instructor instructor = GetInstructorById(LoadInstructors(), instructorId);
            Console.WriteLine("What is the classroom?");
            string courseClassroom = Console.ReadLine();
            Console.WriteLine("What is the course Turn?");
            string courseTurn = Console.ReadLine();
            ClassroomCourse classroomCourse = new ClassroomCourse(courseName, courseDuration, courseCost, instructor, courseClassroom, courseTurn);
            classroomCourse.SaveCourse();
            
            Console.WriteLine($"Course created \n {classroomCourse.GetStringRepresentation()}");

        }
        Thread.Sleep(3000);
    }

    public void StudentMenu(){
        int studentOptionInput = 0;

        Console.Clear();
        Console.WriteLine("Student Menu:");
        Console.WriteLine("Select Student by ID:");
        LoadStudents().ForEach(student => Console.WriteLine(student.DisplayPersonData()));
        int studentID = int.Parse(Console.ReadLine());
        Console.WriteLine($"Student selected: {GetStudentById(LoadStudents(), studentID).DisplayPersonData()}");

        Console.WriteLine("Select an action: \n 1 - Enroll Course\n 2 - Withdraw from Course\n 3 - Add Credit to Student\n" +
        " 4 - Display Enrolled Courses\n 5 - Display Course Assigments\n 6 - Check if Approved");
        
        while (studentOptionInput != 6){

            studentOptionInput = int.Parse(Console.ReadLine());

            if (studentOptionInput == 1){
                
                StudentEnrollCourse(GetStudentById(LoadStudents(), studentID));
                break;
                
            } else if (studentOptionInput == 2){
                
                StudentWithdrawCourse(GetStudentById(LoadStudents(), studentID));

            } else if (studentOptionInput == 3){

                Console.WriteLine("How much credit want to add?");
                float credit = float.Parse(Console.ReadLine());
                GetStudentById(LoadStudents(), studentID).AddCreditToBalance(credit);
                break;

            } /*else if (optionInput == 4){

                LoadGoals();
                
            } else if (optionInput == 5){

                RecordEvent();
                
            }*/
        }

        Thread.Sleep(3000);

    }

    public List<Person> LoadPersons(){

        string[] lines = System.IO.File.ReadAllLines("Persons.txt");


        foreach (string line in lines){
            string[] parts = line.Split(":");
            string objectName = parts[0];
            string values = parts[1];
            string[] valuesParts = values.Split("--");
            
            if (objectName.Equals("Instructor")){
                Instructor instructor = new Instructor(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), valuesParts[3], valuesParts[4], valuesParts[5]);
                GetPersons().Add(instructor);
            } else if (objectName.Equals("Student")){
                Student student = new Student(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), valuesParts[3], valuesParts[4], valuesParts[5]);
                GetPersons().Add(student);
            } 
            
        } return GetPersons();
        
    } 

    public void StudentEnrollCourse(Student student ){

        Console.WriteLine("Select Course by ID:");
        LoadCourses().ForEach(course => Console.WriteLine(course.DisplayCourseData()));
        int courseID = int.Parse(Console.ReadLine());

        student.EnrollCourse(GetCourseById(LoadCourses(),courseID), student.GetBalance());
    }

    public void StudentWithdrawCourse(Student student ){

        student.GetCourses().ForEach(course => Console.WriteLine(course.DisplayCourseData()));
        Console.WriteLine("Select Course by ID:");
        int courseID = int.Parse(Console.ReadLine());

        student.WithdrawFromCourse(GetCourseById(LoadCourses(),courseID));
    }

    public List<Instructor> LoadInstructors(){

        string[] lines = System.IO.File.ReadAllLines("Persons.txt");
        List<Instructor> instructors = new List<Instructor>();
        foreach (string line in lines){
            string[] parts = line.Split(":");
            string objectName = parts[0];
            string values = parts[1];
            string[] valuesParts = values.Split("--");
            
            if (objectName.Equals("Instructor")){
                Instructor instructor = new Instructor(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), valuesParts[3], valuesParts[4], valuesParts[5]);
                instructors.Add(instructor);
            } 
            
        } return instructors;
        
    } 

    public List<Course> LoadCourses(){

        string[] lines = System.IO.File.ReadAllLines("Courses.txt");
        List<Course> courses = new List<Course>();
        foreach (string line in lines){
            string[] parts = line.Split(":");
            string objectName = parts[0];
            string values = parts[1];
            string[] valuesParts = values.Split("--");
            
            if (objectName.Equals("OnlineCourse")){

                OnlineCourse onlineCourse = new OnlineCourse(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), float.Parse(valuesParts[3]), 
                GetInstructorById(LoadInstructors(), int.Parse(valuesParts[4])), valuesParts[7]);
                courses.Add(onlineCourse);

            } else if (objectName.Equals("ClassroomCourse")){
                ClassroomCourse classroomCourse = new ClassroomCourse(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), float.Parse(valuesParts[3]), 
                GetInstructorById(LoadInstructors(), int.Parse(valuesParts[4])), valuesParts[7], valuesParts[8]);
                courses.Add(classroomCourse);
            } 
            
        } return courses;
        
    } 

    public List<Student> LoadStudents(){

        string[] lines = System.IO.File.ReadAllLines("Persons.txt");
        List<Student> students = new List<Student>();
        foreach (string line in lines){
            string[] parts = line.Split(":");
            string objectName = parts[0];
            string values = parts[1];
            string[] valuesParts = values.Split("--");
            
            if (objectName.Equals("Student")){
                Student student = new Student(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), valuesParts[3], valuesParts[4], 
                valuesParts[5], float.Parse(valuesParts[10]));
                students.Add(student);
            } 
            
        } return students;
        
    } 

    public Instructor GetInstructorById(List<Instructor> instructors, int id){
        return instructors.FirstOrDefault(instructor => instructor.GetId() == id);
    }

    public Student GetStudentById(List<Student> students, int id){
        return students.FirstOrDefault(student => student.GetId() == id);
    }

    public Course GetCourseById(List<Course> courses, int id){
        return courses.FirstOrDefault(course => course.GetId() == id);
    }

}