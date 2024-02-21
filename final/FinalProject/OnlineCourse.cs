class OnlineCourse : Course{
    
    private string _webPlatform;

    public OnlineCourse(string name, int monthsDuration, float cost, Instructor instructor, string webPlatform): base(name, monthsDuration, cost, instructor){
        _webPlatform = webPlatform;
    }

    Utils utils = new Utils();

    public string GetWebPlatform(){
        return _webPlatform;
    }
    public void SetWebPlatform(string webPlatform){
        _webPlatform = webPlatform;
    }

    public void ChangeWebSitePlatform(string webPlatform){
        SetWebPlatform(webPlatform);
    }

    //Add all the enrolled students names and WebPlatforms
    public override List<string> DisplayEnrolledStudents(){
        List<string> students = new List<string>();
        GetEnrolledStudents().ForEach(student => students.Add($"{student.GetId()} {student.GetName()} {GetWebPlatform()}"));
        return students;
    }

    public override void SaveCourse(){
        /**Save to the csv file the Course data**/
    }

    public override void LoadCourses(){
        /**Load Courses from the csv**/
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetId()}--{GetName()}--{GetMonthsDuration()}--{GetCost()}--{GetInstructor().GetId()}--{utils.StringifyStudentsList(GetEnrolledStudents())}--" +
        $"{utils.StringifyAssignmentsList(GetAssignments())}--{GetWebPlatform()}";
    }
}