class Rectangle : Shape
{
    private float _heigth;
    private float _length;

    public Rectangle(string color, float length, float heigth): base (color){
        _length = length;
        _heigth = heigth;
    }

    public float GetLength(){
        return _length;
    }

    public void SetLength(float length){
        _length = length;
    }

    public float GetHeigth(){
        return _heigth;
    }

    public void SetHeigth(float heigth){
        _heigth = heigth;
    }

    public override float CalculateArea(){
        return GetHeigth() * GetLength();
    }
}