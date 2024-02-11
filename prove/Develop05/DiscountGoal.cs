class DiscountGoal : Goal
{
    private int _ammountToComplete;

    public DiscountGoal(string shortName, string description, int points, int ammountToComplete) : base (shortName,description,points){
        _ammountToComplete = ammountToComplete;
    }

    public int GetAmountToComplete(){
        return _ammountToComplete;
    }

    public void SetAmountToComplete(int amountToComplete){
        _ammountToComplete = amountToComplete;
    }

    public override void RecordEvent(){
        Console.Write("How many had you done this time? ");
        int discount = int.Parse(Console.ReadLine());
        SetAmountToComplete(GetAmountToComplete() - discount);
    }

    public override bool IsComplete(){
        return GetAmountToComplete() <= 0 ? true:false;
    }

    public override string GetDetailsString(){
        string check = IsComplete()?"X":" ";
        return $"[{check}] {GetShortName()} ({GetDescription()}) -- You need: {GetAmountToComplete()} to complete this task";
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetShortName()}--{GetDescription()}--{GetPoints()}--{GetAmountToComplete()}";
    }
}