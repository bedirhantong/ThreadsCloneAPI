using ThreadsCloneAPI.Models;
namespace ThreadsCloneAPI.Data
{
    public class ApplicationContext
    {
        public static List<Models.Thread> Threads { get; set; }
        static ApplicationContext() { 
            threads = new List<Models.Thread>()
            {
                new Models.Thread() {Id = 1, WhoPosted = "bedirhantng", Content = "Hello World!"},
                new Models.Thread() {Id = 2, WhoPosted = "serhanbymz", Content = "I am Flying"},
            };
        }
    }
}
