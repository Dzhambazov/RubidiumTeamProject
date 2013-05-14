namespace HangMan
{
    public interface IPlayer
    {
         string Name { get; }
         int Mistakes { get; set; }
    }
}