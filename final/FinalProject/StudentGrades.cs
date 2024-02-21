class StudentGrades {

    private Student _student;
    private Assignment _assignment;
    private float _grade;  

  public StudentGrades(Student student, Assignment assignment, float grade){
    _student = student;
    _assignment = assignment;
    _grade = grade;
  }

  public Student GetStudent(){
    return _student;
  }

  public void SetStudent(Student student){
    _student = student;
  }

  public Assignment GetAssignment(){
    return _assignment;
  }

  public void SetAssignment(Assignment assignment){
    _assignment = assignment;
  }

  public float GetGrade(){
    return _grade;
  }
  public void SetGrade(float grade){
    _grade = grade;
  }

}