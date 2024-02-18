class ClassroomCourse : Course{
    
    private string _classroom;
    private string _turn;

    public ClassroomCourse(string name, int monthsDuration, float cost, Instructor instructor, string classroom, string turn): base(name, monthsDuration, cost, instructor){
        _classroom = classroom;
        _turn = turn;
    }

    public ClassroomCourse(string name, int monthsDuration, float cost, Instructor instructor, string classroom): base(name, monthsDuration, cost, instructor){
        _classroom = classroom;
        _turn = "Morning";
    }

    public string GetClassroom(){
        return _classroom;
    }
    public void SetClassroom(string classroom){
        _classroom = classroom;
    }
    public string GetTurn(){
        return _turn;
    }
    public void SetTurn(string turn){
        _turn = turn;
    }

    public void ChangeClassroom(string classroom){
        SetClassroom(classroom);
    }

    public void ChangeTurn(string turn){
        SetTurn(turn);
    }

    public override List<string> DisplayEnrolledStudents(){
        List<string> students = new List<string>();
        foreach(Student student in GetEnrolledStudents()){
            //Add all the enrolled students names, classrooms and turn
        }
        return students;
    }

    public override void SaveCourse(){
        /**Save to the csv file the Course data**/
    }
    public override void LoadCourses(){
        /**Load Courses from the csv**/
    }
}