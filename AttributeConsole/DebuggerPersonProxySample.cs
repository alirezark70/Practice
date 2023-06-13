namespace AttributeConsole
{
    public class DebuggerPersonProxySample
    {
        private readonly Person _person;

        //باید سازنده داشته باشه و اطلاعات شی که بهش چسبیده را بهش بدیم و شخصی سازی را به شکل زیر انجام بدهیم
        public DebuggerPersonProxySample(Person person)
        {
            this._person = person;
        }

        public string FirstName => _person.FirstName;
        public string LastName=>_person.LastName;
        public string NameSpace => "Type Is Class";

        public DateTime CreadteTime => DateTime.Now;
    }
}