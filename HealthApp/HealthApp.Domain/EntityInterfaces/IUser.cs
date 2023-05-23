namespace HealthApp.Domain.EntityInterfaces;

public interface IUser : IEntity
{
    public string Email { get; set; }
    public byte[] Password { get; set; }
    public string Name { get; set; }
}
