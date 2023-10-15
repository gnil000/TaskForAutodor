using Microsoft.OpenApi.Writers;

namespace TaskForAutodor.Models.Repositories
{
    static class FakeTask
    {
        public static List<ResponseView> GoTasks(int count, bool parallel)
        {
            int countr = 0;
            Random random = new Random();
            List <Task> tasks = new List<Task>();
            List<ResponseView> responses = new List<ResponseView>();
            for (int i = 0; i < count; i++)
            {
                Task task = Task.Run(async() =>
                {
                    int time = Random.Shared.Next(100, 1000);//random.Next(100,1000);Random.Shared.Next(100,1000);
                    await Task.Delay(time);
                    //Task.Delay(time).Wait();
                    countr = Interlocked.Increment(ref countr);
                    responses.Add(new ResponseView(countr, time));
                });
                if(parallel)
                    tasks.Add(task);
                else
                    task.Wait();
            }
            Task.WaitAll(tasks.ToArray());
            responses.Sort(delegate (ResponseView x, ResponseView y)
            {
                return x.time.CompareTo(y.time);
            });
            return responses;
        }

    }
}
