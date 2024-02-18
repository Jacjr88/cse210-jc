abstract class Course{
    
    private int _id;
    private string _name;
    private int _monthsDuration;
    private float _cost;
    private Instructor _instructor;
    private List<Student> _enrolledStudents;
    private List<Assignment> _assignments;

    public Course(string name, int monthsDuration, float cost, Instructor instructor){
        Random random = new Random();
        _id = random.Next(0,999999999);
        _name = name;
        _monthsDuration = monthsDuration;
        _cost = cost;
        _instructor = instructor;
        _enrolledStudents = new List<Student>();
        _assignments = new List<Assignment>();
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
    public int GetMonthsDuration(){
        return _monthsDuration;
    }
    public void SetMonthsDuration(int monthsDuration){
        _monthsDuration = monthsDuration;
    }
    public float GetCost(){
        return _cost;
    }
    public void SetCost(float cost){
        _cost = cost;
    }
    public Instructor GetInstructor(){
        return _instructor;
    }
    public void SetInstructor(Instructor instructor){
        _instructor = instructor;
    }
    public List<Student> GetEnrolledStudents(){
        return _enrolledStudents;
    }
    public void SetEnrolledStudents(List<Student> students){
        _enrolledStudents = students;
    }

    public List<Assignment> GetAssignments(){
        return _assignments;
    }
    public void SetAssignments(List<Assignment> assignments){
        _assignments = assignments;
    }

    public void ChangeInstructor(Instructor instructor){
        //**Replace the actual isntructor and change it, update the "Instructors" salary too**//
    }

    public abstract List<string> DisplayEnrolledStudents();

    public void ChangeCost(float newCost){
        //**Update the course cost, update the "Instructors" salary too**//
    }

    public List<string> DisplayAssignments(){
        List<string> assignments = new List<string>();
        foreach(Assignment assignment in GetAssignments()){
            //Add all the assignments of the course
        }
        return assignments;
    }

    public void AddAssignment(Assignment assignment){
        GetAssignments().Add(assignment);
        SetAssignments(GetAssignments());
    }

    public abstract void SaveCourse();

    public abstract void LoadCourses();
}