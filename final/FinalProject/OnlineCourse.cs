class OnlineCourse : Course{
    
    private string _webPlatform;

    public OnlineCourse(string name, int monthsDuration, float cost, Instructor instructor, string webPlatform): base(name, monthsDuration, cost, instructor){
        _webPlatform = webPlatform;
    }

    public string GetWebPlatform(){
        return _webPlatform;
    }
    public void SetWebPlatform(string webPlatform){
        _webPlatform = webPlatform;
    }

    public void ChangeWebSitePlatform(string webPlatform){
        SetWebPlatform(webPlatform);
    }

    public override List<string> DisplayEnrolledStudents(){
        List<string> students = new List<string>();
        foreach(Student student in GetEnrolledStudents()){
            //Add all the enrolled students names and WebPlatforms
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