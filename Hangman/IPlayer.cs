namespace HangMan
{
    public interface IPlayer
    {
         string Name { get; set; }
         int Mistakes { get; set; }
    }
}