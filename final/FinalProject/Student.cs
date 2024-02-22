using System.Diagnostics.Metrics;

class Student : Person {
    private float _avegareGrade;
    private int _absences;
    private List<Course> _courses;
    private List<Assignment> _assignments;
    private float _balance;
    Utils utils = new Utils();

    public Student(string name, int age, string address, string phone, string email):base (name, age, address, phone, email){
        _avegareGrade = 0;
        _absences = 0;
        _courses = new List<Course>();
        _assignments = new List<Assignment>();
        _balance = 0;
    }

    public Student(int id, string name, int age, string address, string phone, string email):base (id, name, age, address, phone, email){
        _avegareGrade = 0;
        _absences = 0;
        _courses = new List<Course>();
        _assignments = new List<Assignment>();
        _balance = 0;
    }

        public Student(int id, string name, int age, string address, string phone, string email, float balance):base (id, name, age, address, phone, email){
        _avegareGrade = 0;
        _absences = 0;
        _courses = new List<Course>();
        _assignments = new List<Assignment>();
        _balance = balance;
    }

    public float GetAverageGrade(){
        return _avegareGrade;
    }

    public void SetAverageGrade(float averageGrade){
        _avegareGrade = averageGrade;
    }

    public int GetAbsenses(){
        return _absences;
    }

    public void SetAbsenses(int absences){
        _absences = absences;
    }

    public List<Course> GetCourses(){
        return _courses;
    }

    public void SetCourses(List<Course> courses){
        _courses = courses;
    }

    public List<Assignment> GetAssignments(){
        return _assignments;
    }

    public void SetAssignments(List<Assignment> assignments){
        _assignments = assignments;
    }

    public float GetBalance(){
        return _balance;
    }

        public void SetBalance(float balance){
        _balance = balance;
    }


    /**Will update the data of a originalPerson to the updatedPerson data**/
    public override void UpdatePersonData(Person originalPerson, Person Person){
        /*
        originalStudent.SetName(updatedStudent.GetName());
        originalStudent.SetAbsenses(updatedStudent.GetAbsenses());
        originalStudent.SetAverageGrade(updatedStudent.GetAverageGrade());
        originalStudent.SetCourses(updatedStudent.GetCourses());
        originalStudent.SetAssignments(updatedStudent.GetAssignments());
        originalStudent.SetBalance(updatedStudent.GetBalance());
        */
    }

    public override string DisplayPersonData(){
        return $"{GetType()} ID:{GetId()} Name:{GetName()} Balance:{GetBalance()}";
    }
    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetId()}--{GetName()}--{GetAge()}--{GetAddress()}--{GetPhone()}--{GetEmail()}--{GetAverageGrade()}--{GetAbsenses()}--" + 
        $"{utils.StringifyCoursesList(GetCourses())}--{utils.StringifyAssignmentsList(GetAssignments())}--{GetBalance()}";
    }

    public string CalculateGradeString(float averageGrade){

        string letter = "";
        string sign = "";

        float remainder = averageGrade % 10;

        if(averageGrade >= 90){
            letter = "A";
        } else if (averageGrade >= 80 && averageGrade < 90){
            letter = "B";
        } else if (averageGrade >= 70 && averageGrade < 80){
            letter = "C";
        } else if (averageGrade >= 60 && averageGrade < 70){
            letter = "D";
        } else if (averageGrade < 60){
            letter = "F";
        }

        if (!letter.Equals("F")){
            if (remainder < 3){
                sign = "-";
            } else if (remainder  >= 7 && !letter.Equals("A")){
                sign = "+";
            }
        }
        
        return $"Your score is {averageGrade}, your grade is {letter} {sign}.";
    }

    public float CalculateGrade(){
        float gradeSum = 0;
        if (GetAssignments().Count() > 0){
            GetAssignments().ForEach(assignment => gradeSum += assignment.GetGrade());
            return gradeSum / GetAssignments().Count();
        } else return gradeSum;
    }

    /**Enroll to some Specific Course and discount cost from balance (add the course to Courses List) **/
    public void EnrollCourse(Course course, float balance){
        List<Course> coursesList = GetCourses();
        if (balance >= course.GetCost()){
            string originalData = GetStringRepresentation();
            coursesList.Add(course);
            SetCourses(coursesList);
            SetBalance(GetBalance() - course.GetCost());
            Console.WriteLine($"Enrolled to {course.GetName()} course ID {course.GetId()}");

            course.GetInstructor().GetStudents().Add(this);
            course.GetInstructor().SetSalary(course.GetInstructor().CalculateSalary());
            course.GetEnrolledStudents().Add(this);
            List<Assignment> assignments = GetAssignments();
            GetAssignments().ForEach(assignments.Add);
            SetAssignments(assignments);
            string newData = GetStringRepresentation();
            UpdateStudentData(RowNumberRecoverer(originalData), newData);

        } else Console.WriteLine($"Credit not enougth to enroll {course.GetName()} course");
    }

    public void AddAssignment(Assignment assignment){
        GetAssignments().Add(assignment);
    }

    /**Withdraw from a Course of the List of Courses(Remove the course from the Courses List) **/
    public void WithdrawFromCourse(Course course){
        GetCourses().Remove(course);
        course.GetInstructor().GetStudents().Remove(this);
        course.GetInstructor().SetSalary(course.GetInstructor().CalculateSalary());
        Console.WriteLine($"You have withdrawed from {course.GetName()} course");
        course.GetAssignments().ForEach(assignment => GetAssignments().Remove(assignment));
    }

    /**Add creedit to the Student balance**/
    public void AddCreditToBalance(float credit){
        string originalData = GetStringRepresentation();
        SetBalance(GetBalance() + credit);
        string newData = GetStringRepresentation();
        UpdateStudentData(RowNumberRecoverer(originalData), newData);
    }
    
    public void AddAbsence(){
        SetAbsenses(GetAbsenses() + 1 );
    }

    public List<string> GetCoursesString(){
        List<string> coursesList = new List<string>();
        GetCourses().ForEach(course => coursesList.Add(course.GetName()));
        return coursesList;
    }

    public void DisplayCourses(){
        GetCourses().ForEach(course => Console.WriteLine(course.GetName()));
    }

    public List<Assignment> GetCourseAssignments(Course course){
        return course.GetAssignments();
    }

    public void DisplayCourseAssignments(){
        GetAssignments().ForEach(assignment => Console.WriteLine($"{assignment.GetCourse().GetName()}    {assignment.GetName()}"));
    }
    //**Add every assignment of each course**//
    public List<Assignment> GetAllCoursesAssignments(){
        List<Assignment> list = new List<Assignment>();
        GetCourses().ForEach(course => course.GetAssignments().ForEach(assignment => list.Add(assignment)));
        return list;
    }

    public List<float> GetAllCoursesAssignmentsGrades(){
        List<float> list = new List<float>();
        GetCourses().ForEach(course => course.GetAssignments().ForEach(assignment => list.Add(assignment.GetGrade())));
        return list;
    }

    public void DisplayAllCoursesAssignments(){
        GetCourses().ForEach(course => course.GetAssignments().ForEach(assignment => Console.WriteLine(assignment.GetName())));
    }

    public bool IsApproved(){
        return GetAllCoursesAssignmentsGrades().All(grade => grade > 75);
    }

    public void UpdateStudentData(int lineNumberToReplaceInput, string newData){

        string[] lines = File.ReadAllLines("Persons.txt");

        int lineNumberToReplace = 3;

        // Nuevo contenido de la línea
        string newLineContent = newData;

        // Reemplazar la línea deseada en el arreglo de cadenas
        if (lineNumberToReplace >= 0 && lineNumberToReplace < lines.Length)
        {
            lines[lineNumberToReplace] = newLineContent;
        }
        else
        {
            Console.WriteLine("Número de línea fuera de rango.");
        }

        // Escribir todas las líneas actualizadas de vuelta al archivo
        using (StreamWriter outputFile = new StreamWriter("Persons.txt"))
        {
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine("Línea reemplazada con éxito.");

    }

    public int RowNumberRecoverer(string originalData){

        string[] lines = System.IO.File.ReadAllLines("Persons.txt");
        List<Student> students = new List<Student>();
        int counter = 0;
        foreach (string line in lines){

            if(line.Equals(originalData)){
                break;
            }
            counter++;
            
        } return counter;
        
    } 
}