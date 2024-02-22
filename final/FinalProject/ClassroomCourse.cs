class ClassroomCourse : Course{
    
    private string _classroom;
    private string _turn;

    public ClassroomCourse(string name, int monthsDuration, float cost, Instructor instructor, string classroom, string turn): base(name, monthsDuration, cost, instructor){
        _classroom = classroom;
        _turn = turn;
    }

    public ClassroomCourse(int id, string name, int monthsDuration, float cost, Instructor instructor, string classroom, string turn): base(id, name, monthsDuration, cost, instructor){
        _classroom = classroom;
        _turn = turn;
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

    Utils utils = new Utils();

    public override List<string> DisplayEnrolledStudents(){
        List<string> students = new List<string>();
        GetEnrolledStudents().ForEach(student => students.Add($"{student.GetId()} {student.GetName()} {GetClassroom()} {GetTurn()}"));
        return students;
    }

    public override void SaveCourse(){
        using (StreamWriter outputFile = new StreamWriter("Courses.txt", true)){
            outputFile.WriteLine(GetStringRepresentation());
        }
    }
    public override void LoadCourses(){
        /**Load Courses from the csv**/
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetId()}--{GetName()}--{GetMonthsDuration()}--{GetCost()}--{GetInstructor().GetId()}--{utils.StringifyStudentsList(GetEnrolledStudents())}--" +
        $"{utils.StringifyAssignmentsList(GetAssignments())}--{GetClassroom()}--{GetTurn()}";
    }
}