class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus) : base (shortName,description,points){
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string shortName, string description, int points,int bonus, int target, int amountAcomplished) : base (shortName,description,points){
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountAcomplished;
    }

    public int GetAmountCompleted(){
        return _amountCompleted;
    }

    public void SetAmountCompleted(int amountCompleted){
        _amountCompleted = amountCompleted;
    }
    public int GetTarget(){
        return _target;
    }

    public void SetTarget(int target){
        _target = target;
    }

    public int GetBonus(){
        return _bonus;
    }

    public void SetBonus(int bonus){
        _bonus = bonus;
    }

    public override void RecordEvent(){
        SetAmountCompleted(GetAmountCompleted() + 1);
        if(IsComplete()){
            SetPoints(GetPoints() + GetBonus());
        }
    }

    public override bool IsComplete(){
        return GetAmountCompleted()<GetTarget()?false:true;
    }

    public override string GetDetailsString(){
        string check = IsComplete()?"X":" ";
        return $"[{check}] {GetShortName()} ({GetDescription()}) -- Currently completed: {GetAmountCompleted()}/{GetTarget()}";
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetShortName()}--{GetDescription()}--{GetPoints()}--{GetBonus()}--{GetTarget()}--{GetAmountCompleted()}";
    }
}