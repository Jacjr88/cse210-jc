class Instructor : Person {
    private List<Course> _coursesOnCharge;
    private List<Student> _students;
    private List<Assignment> _assignmentsCreated;
    private float _salary;

    public Instructor(string name, int age, string address, string phone, string email, float salary):base (name, age, address, phone, email){
        _students = new List<Student>();
        _coursesOnCharge = new List<Course>();
        _assignmentsCreated = new List<Assignment>();
        _salary = salary;
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
        return $"{GetType()}:{GetId()}--{GetName()}--{GetSalary()}--{GetAddress()}";
    }

    //**The salary of the Instructor will be the 50% of the tuiton of all the Students registered in his/her course**//
    public float CalculateSalary(){
        GetCourses();
        //**Sumarize all tuiton of all the Students registered on the courses and return the half of it**//
        //SetSalary(The compute will update the salary of the instructor)
        return 0;
    }

    public void AddNewCourse(Course course){
        /**Will add a new Course for this instructor(add the course to Courses List)**/
    }

    public void GradeAssignment(Student student, Assignment assignment, float grade){
        /**Grade the specific assignment to the student**/
    }

}