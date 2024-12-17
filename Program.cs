namespace day15battleship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Console.LargestWindowWidth);
            //Console.WriteLine(Console.LargestWindowHeight);
            Console.SetWindowSize(240,63);// 최대 수치
            
            Console.SetBufferSize(1000, 1000);
            Game game = new Game();
            game.Play();



        }
    }
}
