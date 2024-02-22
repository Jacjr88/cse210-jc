class Instructor : Person {
    private List<Course> _coursesOnCharge;
    private List<Student> _students;
    private List<Assignment> _assignmentsCreated;
    private float _salary;

    public Instructor(string name, int age, string address, string phone, string email):base (name, age, address, phone, email){
        _students = new List<Student>();
        _coursesOnCharge = new List<Course>();
        _assignmentsCreated = new List<Assignment>();
        _salary = 0;
    }

    public Instructor(int id, string name, int age, string address, string phone, string email):base (id, name, age, address, phone, email){
        _students = new List<Student>();
        _coursesOnCharge = new List<Course>();
        _assignmentsCreated = new List<Assignment>();
        _salary = 0;
    }

    public List<Student> GetStudents(){
        return _students;
    }
    public void SetStudents(List<Student> students){
        _students = students;
    }

    public List<Course> GetCourses(){
        return _coursesOnCharge;
    }
    public void SetCourses(List<Course> courses){
        _coursesOnCharge = courses;
    }

    public List<Assignment> GetAssignments(){
        return _assignmentsCreated;
    }

    public void SetAssignments(List<Assignment> assignmentsCreated){
        _assignmentsCreated = assignmentsCreated;
    }

    public float GetSalary(){
        return _salary;
    }

    public void SetSalary(float salary){
        _salary = salary;
    }

    Utils utils = new Utils();

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
        return $"{GetType()} ID:{GetId()} Name:{GetName()} salary:{GetSalary()}";
    }
    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetId()}--{GetName()}--{GetAge()}--{GetAddress()}--{GetPhone()}--{GetEmail()}--{utils.StringifyCoursesList(GetCourses())}--{utils.StringifyStudentsList(GetStudents())}--" + 
        $"{utils.StringifyAssignmentsList(GetAssignments())}--{GetSalary()}";
    }

    //**The salary of the Instructor will be the 50% of the tuiton of all the Students registered in his/her course**//
    public float CalculateSalary(){
        float salary = 0;
        GetStudents().ForEach(student => GetCourses().ForEach(course => salary += course.GetCost()));

        //**Sumarize all tuiton of all the Students registered on the courses and return the half of it**//
        //SetSalary(The compute will update the salary of the instructor)
        return salary * 0.5f;
    }

    /**Will add a new Course for this instructor(add the course to Courses List)**/
    public void AddNewCourse(Course course){
        List<Course> courses = GetCourses();
        courses.Add(course);
        SetCourses(courses);
    }

    public void AddAssignment(Assignment assignment){
        List<Assignment> assignments = GetAssignments();
        assignments.Add(assignment);
        SetAssignments(assignments);
    }

    /**Grade the specific assignment to the student**/
    public void GradeAssignment(Student student, Assignment assignment, float grade){
        student.GetAssignments().ForEach(assignment => {
            if (assignment.Equals(assignment)){
                assignment.SetGrade(grade);
                student.SetAverageGrade(student.CalculateGrade());
                new StudentGrades(student,assignment,grade);
            }
        });
    }

    public Instructor GetInstructorById(List<Instructor> instructors, int id){
        return instructors.FirstOrDefault(instructor => instructor.GetId() == id);
    }
    

    /*public void SaveInstructor(){
        using (StreamWriter outputFile = new StreamWriter("Persons.txt", true)){
            outputFile.WriteLine(GetStringRepresentation());
        }
    }
*/
    public Instructor LoadInstructor(){

        string[] lines = System.IO.File.ReadAllLines("Persons.txt");
        Instructor instructor;

        foreach (string line in lines){
            string[] parts = line.Split(":");
            string objectName = parts[0];
            string values = parts[1];
            string[] valuesParts = values.Split("--");
             
            if (objectName.Equals("Instructor")){
                //public Instructor(int id, string name, int age, string address, string phone, string email):base (id, name, age, address, phone, email){
                instructor = new Instructor(int.Parse(valuesParts[0]), valuesParts[1], int.Parse(valuesParts[2]), valuesParts[3], valuesParts[4], valuesParts[5]);
                return instructor;
            } 
            
        } return null;
        
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

}