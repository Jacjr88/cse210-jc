abstract class Assignment{
    private int _id;
    private string _name;
    private Course _course;
    private List<Student> _studentsAssigned;
    private Instructor _instructor;
    private float _grade;
    private DateTime _dueDate;

    public Assignment(string name, Course course, DateTime dueDate){
        Random random = new Random();
        _id = random.Next(0,999999999);
        _name = name;
        _studentsAssigned = course.GetEnrolledStudents();
        //AssignToAllStudentsInCourse(GetStudentsAssigned());
        _instructor = course.GetInstructor();
        _grade = 0;
        _dueDate = dueDate;
        SetCourse(course);
        course.GetInstructor().AddAssignment(this);
        course.GetEnrolledStudents();
    }

    public int GetId(){
        return _id;
    }

    public string GetName(){
        return _name;
    }
    public void SetName(string name){
        _name = name;
    }
    public Course GetCourse(){
        return _course;
    }
    public void SetCourse(Course course){
        _course = course;
    }
    public List<Student> GetStudentsAssigned(){
        return _studentsAssigned;
    }
    public void SetStudentsAssigned(List<Student> students){
        _studentsAssigned = students;
    }
    public Instructor GetInstructor(){
        return _instructor;
    }
    public void SetInstructor(Instructor instructor){
        _instructor = instructor;
    }
    public float GetGrade(){
        return _grade;
    }
    public void SetGrade(float grade){
        _grade = grade;
    }
    public DateTime GetDueDate(){
        return _dueDate;
    }
    public void SetDueDate(DateTime dueDate){
        _dueDate = dueDate;
    }

    public List<Student> AddAssignedStudents(List<Student> students){
        
        foreach(Student student in students){
            student.AddAssignment(this);
        }
        return students;
    }

    public void AssignToAllStudentsInCourse(List<Student> students){
        List<Assignment> studentAssignments = new List<Assignment>();
        students.ForEach(student => {
            student.SetAssignments(studentAssignments);
            student.GetCourses()
            .ForEach(course => course.GetAssignments()
            .ForEach(assignment => studentAssignments.Add(assignment)));
        });
    }
    
    public void AddStudentsAssigned(Student student){
        GetStudentsAssigned().Add(student);
        SetStudentsAssigned(GetStudentsAssigned());
    }

    public abstract string DisplayAssignmentData();

    public abstract void SaveAssignment();

    public abstract void UpdateAssignment(int id);

    public abstract string GetStringRepresentation();

    public abstract void GradeAssignment(int id, float grade);

}