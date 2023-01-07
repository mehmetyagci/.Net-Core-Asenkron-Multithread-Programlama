namespace TaskStartNew {


    public class Status {
        public int ThreadId { get; set; }

        public DateTime DateTime { get; set; }
    }

    internal   class Program {
        private async static Task Main(string[] args) {

            var myTask = Task.Factory.StartNew((Obj) => 
            {
                Console.WriteLine("myTask çalıştı");
                var status = Obj as Status;

                status.ThreadId = Thread.CurrentThread.ManagedThreadId;
            },new Status () {
                DateTime = DateTime.Now,
            });

            await myTask;

            Status s = myTask.AsyncState as Status;

            Console.WriteLine(s.DateTime);
            Console.WriteLine(s.ThreadId);
        }
    }
}