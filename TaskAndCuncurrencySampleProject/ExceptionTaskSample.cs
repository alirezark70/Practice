namespace TaskAndConcurrencySampleProject
{
    public class ExceptionTaskSample
    {
        public void Start()
        {
            Task<int> badMethod = Task.Run(() => BadMethod(10, null));

            try
            {
                //برعکس ترد ما با ویت می تونیم خطا را مدیریت کنیم
                badMethod.Wait();
                Console.WriteLine("BadMethod Finished");
            }
            catch (ArgumentException ex)
            {
                //اگر به هر دلیلی عملیات کنسل شود مقدار پروپرتی زیر 
                //true
                // می شود
                Console.WriteLine(badMethod.IsCanceled);

                //اگر به هر دلیلی خطای در فرایند انجام تسک باشد مقدار زیر
                //true
                //می شود
                Console.WriteLine(badMethod.IsFaulted);
                Console.WriteLine(ex.Message);
            }
        }


        public int BadMethod(int? number1,int? number2)
        {
            if(number1 is null)
                throw new ArgumentNullException(nameof(number1));

            if (number2 is null)
                throw new ArgumentNullException(nameof(number2));

            return number1.Value + number2.Value; 
        }

    }
}
