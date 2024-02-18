using System.Formats.Asn1;
using System.Reflection;
using System.Runtime.InteropServices;

class Student : Person {
    private float _avegareGrade;
    private int _absences;
    private List<Course> _courses;
    private List<Assignment> _assignments;
    private float _balance;

    public Student(string name, int age, string address, string phone, string email):base (name, age, address, phone, email){
        _avegareGrade = 0;
        _absences = 0;
        _courses = new List<Course>();
        _assignments = new List<Assignment>();
        _balance = 0;
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
        return $"{GetType()}:{GetId()}--{GetName()}--{GetBalance()}--{GetAddress()}";
    }

    public string CalculateGrade(float averageGrade){
        return "Grade";
    }

    public void EnrollCourse(Course course, float balance){
        /**Enroll to some Specific Course (add the course to Courses List) **/
    }

    public void WithdrawFromCourse(Course course){
        /**Withdraw from a Course of the List of Courses(Remove the course from the Courses List) **/
    }

    public void AddCreditToBalance(float credit){
        /**Add creedit to the Student balance**/
    }
    
    public void AddAbsence(){
        SetAbsenses(GetAbsenses() + 1 );
    }

    public List<string> DisplayCourses(){
        List<string> coursesList = new List<string>();
        foreach(Course course in GetCourses()){
            //coursesList.Add(course.GetName());
            coursesList.Add("course");
        }
        return coursesList;
    }

    public List<Assignment> DisplayCourseAssignments(Course course){
        //return course.GetAssignments();
        List<Assignment> list = new List<Assignment>();
        return list;
    }

    public List<Assignment> DisplayAllCoursesAssignments(){
        //return course.GetAssignments();
        List<Assignment> list = new List<Assignment>();
        foreach(Course course in GetCourses()){
            //**Add every assignment of each course**//
        }
        
        return list;
    }

    public bool IsApproved(){
        //**Check if all the assignment are approved, if condition is OK return true**//
        return false;
    }

}