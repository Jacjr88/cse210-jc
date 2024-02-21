class Utils{

    public string StringifyCoursesList(List<Course> courses){
       List<string> ids = new List<string>();
       courses.ForEach(course => ids.Add(course.GetId().ToString()));
        string idsList = string.Join( ",", ids);
        string result = $"[{idsList}]";
        return result;
    }

    public string StringifyAssignmentsList(List<Assignment> assignments){
       List<string> ids = new List<string>();
       assignments.ForEach(assignment => ids.Add(assignment.GetId().ToString()));
        string idsList = string.Join( ",", ids);
        string result = $"[{idsList}]";
        return result;
    }

    public string StringifyStudentsList(List<Student> students){
       List<string> ids = new List<string>();
       students.ForEach(student => ids.Add(student.GetId().ToString()));
        string idsList = string.Join( ",", ids);
        string result = $"[{idsList}]";
        return result;
    }

}