using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProject
{
    public class CancellationTokenSample
    {
        public async void Start()
        {
            var taskCancel=new CancellationTokenSource();
            var task = PrintNumber(10, taskCancel.Token);

            Console.WriteLine("If You Want To Cancele Task Please Print And Send yes");
            var consoleCanceled = Console.ReadLine();

            if(string.IsNullOrEmpty(consoleCanceled) && consoleCanceled=="yes")
            {
                taskCancel.Cancel();
            }
            await task;
            try
            {
                Console.WriteLine($"Print Number : {task.Result}");

                Console.WriteLine("TaskDone");
            }
            catch (TaskCanceledException ex)
            {
                var taskStatus = task.Status;
                var isCanceled = task.IsCanceled;

                Console.WriteLine($"Task Status - Status : {taskStatus} And Is Canceled : {isCanceled}");
            }

        }


        public async Task<int> PrintNumber(int numberCount,CancellationToken cancellationToken)
        {
            for (int i = 0; i < numberCount; i++)
            {
                await Task.Delay(2000);
                return  i;
            }
            
            return 0;


        }
    }
}
