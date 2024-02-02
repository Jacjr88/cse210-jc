public class BreathingActivity : Activity{


    public BreathingActivity(){
        SetName("Breathing Activity");
        SetDescription("This activity will help you relax by " + 
        "walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        SetDuration(0);
    }

    public void Run(){

        DisplayStartingMessage();

        BreathingAction(GetDuration());

        DisplayEndingMessage();

    }

    public void BreathingAction(int seconds){
        Console.Clear();
        Console.WriteLine("Ready to Start?");

        ShowAnimation(3);

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds-6);

        Console.Write($"Breathe in... ");
        ShowCountDown(3);

        Console.Write("\nBreathe out... ");
        ShowCountDown(3);

        while(startTime < futureTime){

            Console.Write("\nBreathe in... ");
            ShowCountDown(4);

            Console.Write("\nBreathe out... ");
            ShowCountDown(6);

            startTime = DateTime.Now;
        }

    }

}