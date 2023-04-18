namespace HealthApp.Domain.Entities;

public class InformationAboutPatient
{
    public InformationAboutPatient()
    {
        Illnesses = new();
    }
    public InformationAboutPatient(int age, bool male, double weight)
    {
        Age = age;
        Male = male;
        Weight = weight;
        Illnesses = new();
    }
    public void AddIllness(string illness)
    {
        Illnesses.Add(illness);
    }
    public int Age { get; set; }
    public bool Male { get; set; }
    public double Weight { get; set; }
    public List<string> Illnesses { get; set; }
}
