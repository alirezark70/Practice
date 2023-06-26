// See https://aka.ms/new-console-template for more information

using NutshelBooK;
using NutshelBool;
using static NutshelBool.CSharpExample;
using person = NutshelBooK.Person;
using child = NutshelBooK.Child;
CSharpExample examp = new CSharpExample();

#region Page30 Until 63
//examp.NondestructiveMutationForAnonymousypes();

//examp.NewDeconstructionSyntax();

//var logger = (IExampleLogger)examp;
//logger.ExampleLog("Test");


Page30Until60Nutshel page30Until60 = new();

//page30Until60.Literals();

//page30Until60.SplitFullName("Alireza Rezaee",out string firstName,out string lastName);

//int number = 100;

//page30Until60.TestRef(ref number);

//Console.WriteLine(number);
#endregion


#region Page 60 Until 100
//NutshelPage67Until100 page67Until100 = new ();

//page67Until100.ChangeFullName();

//page67Until100.TellMeTheType("hi");


//page67Until100.CheckedAndUnchecked();
#endregion


#region Indexer In Ef core
public class Blog
{
    private readonly Dictionary<string,object> _data = new Dictionary<string,object>();

    public int BlogId { get; set; }

    public object this[string key]
    {
        get { return _data[key]; }
        set { _data[key] = value; }
    }
}
#endregion

#region Page 101 Until 200

child child=new child("Alireza","Rezaee",32);
child.AgeChecker();


#endregion
Console.ReadLine();
