using System.Data;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager(){
        _goals = new List<Goal>();
        _score = 0;
    }

    public List<Goal> GetGoals(){
        return _goals;
    }

    public void SetGoals(List<Goal> goals){
        _goals = goals;
    }

    public int GetScore(){
        return _score;
    }

    public void SetScore(int score){
        _score = score;
    }

    public void Start(){
        int optionInput = 0;
        while (optionInput != 6){
            //Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:\n  1- Create New Goal\n  2- List Goals\n  3- Save Goals\n  4- Load Goals\n  5- Record Event\n  6- Quit");
            Console.Write("Select a choice from the menu: ");
            optionInput = int.Parse(Console.ReadLine());

            if (optionInput == 1){
                
                CreateGoal();
                
            } else if (optionInput == 2){
                
                ListGoalDetails();

            } else if (optionInput == 3){

                SaveGoals();

            } else if (optionInput == 4){

                LoadGoals();
                
            } else if (optionInput == 5){

                RecordEvent();
                
            }
        }
    }

    public void DisplayPlayerInfo(){
        Console.WriteLine($"You have: {GetScore()} points\n");
    }

    public void ListGoalNames(){
        int counter = 1;
        Console.WriteLine("The goals are:");
        foreach(Goal goal in GetGoals()){
            Console.WriteLine($"{counter}. {goal.GetDescription()}");
            counter++;
        }
    }

    public void ListGoalDetails(){
        if (GetGoals().Count > 0){
            int counter = 1;
            Console.WriteLine("The goals are:");
            foreach(Goal goal in GetGoals()){
                Console.WriteLine($"{counter}. {goal.GetDetailsString()}");
                counter++;
            }       
        }
    }

    public void CreateGoal(){

        Console.WriteLine("The types of Goals are:\n 1- Simple Goal\n 2- Eternal Goal\n 3- Checklist Goal\n 4- Discount Goal");
        
        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());

        if (goalType == 1){
            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();
            Console.Write("What is the goal description? ");
            string goalDescription = Console.ReadLine();
            Console.Write("How many points will give you for accomplish it? ");
            int goalPoints = int.Parse(Console.ReadLine());
            SimpleGoal simpleGoal = new SimpleGoal(goalName,goalDescription, goalPoints);
            GetGoals().Add(simpleGoal);
        }

        if (goalType == 2){
            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();
            Console.Write("What is the goal description? ");
            string goalDescription = Console.ReadLine();
            Console.Write("How many points will give you for accomplish it? ");
            int goalPoints = int.Parse(Console.ReadLine());
            EternalGoal eternalGoal = new EternalGoal (goalName,goalDescription, goalPoints);
            GetGoals().Add(eternalGoal);
        }

        if (goalType == 3){
            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();
            Console.Write("What is the goal description? ");
            string goalDescription = Console.ReadLine();
            Console.Write("How many points will give you for accomplish it? ");
            int goalPoints = int.Parse(Console.ReadLine());
            Console.Write("How many times you want to complete this task to get a bonus? ");
            int timesToBonus = int.Parse(Console.ReadLine());
            Console.Write("How many points will give you this bonus? ");
            int bonusPoints = int.Parse(Console.ReadLine());
            ChecklistGoal checklistGoal = new ChecklistGoal (goalName,goalDescription, goalPoints, timesToBonus, bonusPoints);
            GetGoals().Add(checklistGoal);
        }

        if (goalType == 4){
            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();
            Console.Write("What is the goal description? ");
            string goalDescription = Console.ReadLine();
            Console.Write("How many points will give you for accomplish it? ");
            int goalPoints = int.Parse(Console.ReadLine());
            Console.Write("How much you need to do to consider it acomplished? ");
            int ammountToComplete = int.Parse(Console.ReadLine());
            DiscountGoal discountGoal = new DiscountGoal (goalName,goalDescription, goalPoints, ammountToComplete);
            GetGoals().Add(discountGoal);
        }

    }
    public void RecordEvent(){
        ListGoalNames();
        Console.Write("Which task you had completed? ");
        int goalInput = int.Parse(Console.ReadLine());
        GetGoals()[goalInput-1].RecordEvent();
        if(GetGoals()[goalInput-1].GetType() == typeof(DiscountGoal)){
            SetScore(GetGoals()[goalInput-1].IsComplete() ?
            GetScore() + GetGoals()[goalInput-1].GetPoints() : 
            GetScore());
        } else SetScore(GetScore() + GetGoals()[goalInput-1].GetPoints());
    }

    public void SaveGoals(){
        Console.Write("Which name will you give to the file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename)){
            outputFile.WriteLine(GetScore());
            foreach(Goal goal in GetGoals()){
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }
    }

    public void LoadGoals(){
        Console.Write("Which file you want to read? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines){
            if (line.Length<5){
                SetScore(int.Parse(line));
            } else {
                string[] parts = line.Split(":");
                string objectName = parts[0];
                string values = parts[1];
                string[] valuesParts = values.Split("--");

                if (objectName.Equals("SimpleGoal")){
                    
                    SimpleGoal simpleGoal = new SimpleGoal(valuesParts[0], valuesParts[1], int.Parse(valuesParts[2]), bool.Parse(valuesParts[3]));
                    GetGoals().Add(simpleGoal);
                } else if (objectName.Equals("EternalGoal")){
                    EternalGoal eternalGoal = new EternalGoal(valuesParts[0], valuesParts[1], int.Parse(valuesParts[2]));
                    GetGoals().Add(eternalGoal);
                } else if (objectName.Equals("ChecklistGoal")){
                    ChecklistGoal checklistGoal = new ChecklistGoal(valuesParts[0], valuesParts[1], int.Parse(valuesParts[2]), 
                    int.Parse(valuesParts[3]), int.Parse(valuesParts[4]), int.Parse(valuesParts[5]));
                    GetGoals().Add(checklistGoal);
                } else if (objectName.Equals("DiscountGoal")){
                    DiscountGoal discountGoal = new DiscountGoal(valuesParts[0], valuesParts[1], int.Parse(valuesParts[2]), int.Parse(valuesParts[3]));
                    GetGoals().Add(discountGoal);
                }
            }
        }
    }
}