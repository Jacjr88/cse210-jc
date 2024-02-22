abstract class Person {
    private int _id;
    private string _name;
    private int _age;
    private string _address;
    private string _phone;
    private string _email;

    public Person(string name, int age, string address, string phone, string email){
        Random random = new Random();
        _id = random.Next(0,999999999);
        _name = name;
        _age = age;
        _address = address;
        _phone = phone;
        _email = email;
    }

    public Person(int id, string name, int age, string address, string phone, string email){
        _id = id;
        _name = name;
        _age = age;
        _address = address;
        _phone = phone;
        _email = email;
    }

    public Person(){

    }

    public int GetId(){
        return _id;
    }

    public void SetId(int id){
        _id = id;
    }

    public string GetName(){
        return _name;
    }

    public void SetName(string name){
        _name = name;
    }

    public int GetAge(){
        return _age;
    }

    public void SetAge(int age){
        _age = age;
    }

    public string GetAddress(){
        return _address;
    }

        public void SetAddress(string address){
        _address = address;
    }

    public string GetPhone(){
        return _phone;
    }
        public void SetPhone(string phone){
        _phone = phone;
    }
    public string GetEmail(){
        return _email;
    }
        public void SetEmail(string email){
        _email = email;
    }

    /**Will update the data of a originalPerson to the updatedPerson data**/
    public abstract void UpdatePersonData(Person originalPerson, Person person);

    public abstract string DisplayPersonData();

    public abstract string GetStringRepresentation();

    public void SavePerson(){
        using (StreamWriter outputFile = new StreamWriter("Persons.txt", true)){
            outputFile.WriteLine(GetStringRepresentation());
        }
    }

}