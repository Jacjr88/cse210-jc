class Circle : Shape
{
    private float _radius;

    public Circle(string color, float radius ): base (color){
        _radius = radius;
    }

    public float GetRadius(){
        return _radius;
    }

    public void SetRadius(float radius){
        _radius = radius;
    }

    public override float CalculateArea(){
        return (float)((float) Math.PI * Math.Pow(GetRadius(), 2)); 
    }
}