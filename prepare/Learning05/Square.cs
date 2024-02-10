class Square : Shape
{
    private float _sideLength;

    public Square(string color, float sideLength ): base (color){
        _sideLength = sideLength;
    }

        public float GetSideLength(){
        return _sideLength;
    }

    public void SetSideLength(float sideLength){
        _sideLength = sideLength;
    }

    public override float CalculateArea(){
        return GetSideLength() * GetSideLength();
    }
}