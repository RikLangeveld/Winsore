using System;

namespace Winsore
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Winsore game = new Winsore())
            {
                game.Run();
            }
        }
    }
#endif
}

