class Exam : Assignment{
    private int _attempts;
    private int _attemptsLimit;
    private bool _approved;


    public Exam(string name, Course course, DateTime dueDate, int attemptsLimit) : base (name, course, dueDate){
       _attempts = 0;
       _attemptsLimit = attemptsLimit;
       _approved = false;
    }

    public int GetAttempts(){
        return _attempts;
    }
    public void SetAttempts(int attempts){
        _attempts = attempts;
    }

    public int GetAttemptsLimit(){
        return _attemptsLimit;
    }
    public void SetAttemptsLimit(int attemptsLimit){
        _attemptsLimit = attemptsLimit;
    }
    public bool GetApproved(){
        return _approved;
    }
    public void SetApproved(bool approved){
        _approved = approved;
    }
    public override void GradeAssignment(int id, float grade){
        GetExamById(id);
        SetGrade(grade);
        SetApproved(IsApproved(grade));
    }

    public bool IsApproved(float grade){
       return grade > 70? true : false;
    }

    public Exam GetExamById(int id){
        //**Read the Assignment file and get the line that matches the id of argument**/ 
        return null;
    }

    public void AddAttempt(){
        SetAttempts(GetAttempts()+1);
    }

    public override string DisplayAssignmentData(){
        return $"{GetType()} ID:{GetId()} Name:{GetName()} approved:{GetApproved()} grade: {GetGrade()}";
    }

    public override void SaveAssignment(){
        //Save to assignments file with the  GetStringRepresentation() format;
    }

    public override string GetStringRepresentation(){
        //Add all attributes
        return $"{GetType()}:{GetId()}--{GetName()}--{GetCourse()}--{GetGrade()}";
    }

    public override void UpdateAssignment(int id){
        GetExamById(11);
        //Update the assignment data replacing it in the file;
    }

}