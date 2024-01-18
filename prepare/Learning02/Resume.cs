public class Resume
{
    public string _personName;
    public List<Job> _jobList = new List<Job>();

    public Resume(){
    }

    public void DisplayResume()
        {
            Console.WriteLine($"{_personName}");
            foreach(Job job in _jobList){
                job.DisplayJobInformation();
            }

        }
}