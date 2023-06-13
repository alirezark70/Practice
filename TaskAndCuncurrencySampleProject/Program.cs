// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using TaskAndConcurrencySampleProject;


ContinuationsTaskSample continuationsTaskSample = new();

continuationsTaskSample.StartContinueWith();


//TaskSample task = new();
//task.StartTask();

//var threadPoolSample=new ThreadPoolSample();
//threadPoolSample.TakeThreadFromThreadPool();
//Console.ReadLine();
//var threadPriority=new Thread_Priority();

//threadPriority.Start();

//Console.ReadLine();

//var threadClass = new ThreadClassSample();

//Thread dashThread = new Thread(threadClass.PrintDash);
//یک ترد درست می کنیم و یک دلیگید میگیره و ما متد بهش پاس میدیم
//استارت می کنیم

//گذاشتن اسم بر روی ترد
//dashThread.Name = "Dash Thread Name";

//Console.WriteLine($"Thread Is Alive Before Start : {Thread.CurrentThread.IsAlive}");
//dashThread.Start();
//Console.WriteLine($"Thread Is Alive After Start : {Thread.CurrentThread.IsAlive}");
//threadClass.PrintStar();

//threadClass.PrintDash();






//JonAndSleepThreadSampleClass jonAndSleep = new JonAndSleepThreadSampleClass();
//jonAndSleep.ThreadStateCheck();


//SharedAndLocalStateClass stateClass = new SharedAndLocalStateClass();
//stateClass.Start();

//ThreadWithParameterClass parameterClass = new ThreadWithParameterClass();
//parameterClass.MultipleParameterExecute("Alireza","Rezaee");

//ExceptionThreadsClass exceptionThreadsClass = new ExceptionThreadsClass();

//exceptionThreadsClass.Execute();
//Console.ReadLine();
