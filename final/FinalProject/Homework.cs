class Homework : Assignment{
    private bool _late;
    private bool _submitted;
    private DateTime _submitDate;

    Utils utils = new Utils();

    public Homework(string name, Course course, DateTime dueDate) : base (name, course, dueDate){
       _late = false;
       _submitted = false;
       SetStudentsAssigned(AddAssignedStudents(course.GetEnrolledStudents()));
    }

    public bool GetLate(){
        return _late;
    }
    public void SetLate(bool late){
        _late = late;
    }
    public bool GetSubmitted(){
        return _submitted;
    }
    public void SetSubmitted(bool submitted){
        _submitted = submitted;
        SetSubmitDate(DateTime.Now);
        SetLate(IsLate());
        
    }
    public DateTime GetSubmitDate(){
        return _submitDate;
    }
    public void SetSubmitDate(DateTime sumbitDate){
        _submitDate = sumbitDate;
    }

    public bool IsLate(){
        if(DateTime.Now > GetDueDate()){
            return true;
        } else return false;
    }

    public void SubmitHomework(Student student, int homeworkId){
        student.GetAssignments();
        Homework homework = GetHomeworkById(21);
        homework.SetSubmitted(true);
    }

    public Homework GetHomeworkById(int id){
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        /*List<int> intIds = new List<int>();
        string ids = "586330776,447387008";
        string[] parts = ids.Split(",");
            foreach(string id in parts){
                intIds.Add(int.Parse(id));
            }

        foreach(int id in intIds){
            Console.WriteLine(id);
        }*/

        //**Read the Assignment file and get the line that matches the id of argument**/ 
        return null;
    }

    public override string DisplayAssignmentData(){
        return $"{GetType()} ID:{GetId()} Name:{GetName()} submitted:{GetSubmitted()} grade: {GetGrade()}";
    }

    public override void GradeAssignment(int id, float grade){
        //Get the homework and set the grade
        Homework homework = GetHomeworkById(id);
        homework.SetGrade(grade);
    }

    public override void SaveAssignment(){
        //Save to assignments file with the  GetStringRepresentation() format;
    }

    public override string GetStringRepresentation(){
        //Add all attributes
        return $"{GetType()}:{GetId()}--{GetName()}--{GetCourse().GetId()}--{utils.StringifyStudentsList(GetStudentsAssigned())}--{GetInstructor().GetId()}--" +
        $"{GetGrade()}--{GetDueDate().ToShortDateString()}";
    }

    public override void UpdateAssignment(int id){
        GetHomeworkById(11);
        //Update the assignment data replacing it in the file;
    }

}