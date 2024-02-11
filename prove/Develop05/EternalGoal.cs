class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base (shortName,description,points){
    }

    public override void RecordEvent(){

    }

    public override bool IsComplete(){
        return false;
    }

    public override string GetStringRepresentation(){
        return $"{GetType()}:{GetShortName()}--{GetDescription()}--{GetPoints()}";
    }


}