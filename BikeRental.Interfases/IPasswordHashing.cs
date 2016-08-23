namespace BikeRental.Interfases
{
    public interface IPasswordHashing
    {
        string GenerateSaltValue();
        string HashPassword(string password, string saltValue);
    }
}
