class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points) : base (shortName,description,points){
        _isComplete = false;
    }

    public SimpleGoal(string shortName, string description, int points, bool isComplete) : base (shortName,description,points){
        _isComplete = isComplete;
    }

    public bool GetIsComplete(){
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete){
        _isComplete = isComplete;
    }

    public override void RecordEvent(){
        SetIsComplete(true);
        
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetShortName()}--{GetDescription()}--{GetPoints()}--{GetIsComplete()}";
    }
}