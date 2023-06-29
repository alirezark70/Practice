// See https://aka.ms/new-console-template for more information

using NutshelBooK;
using static NutshelBool.CSharpExample;
using person = NutshelBooK.Person;
using childClasses = NutshelBooK.Child;
using NutshelBool;


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




#region Page 101 Until 200


//CSharpExample examp = new CSharpExample();
//NutshelBooK.Child ghf = new("Alireza", "Rezaee", 30);

List<FinalizersExample> finalizers = new List<FinalizersExample>();
finalizers.Add(new FinalizersExample());
finalizers = null;

ExampelCovariant exampelCovariant = new ExampelCovariant();

exampelCovariant.Test();
#endregion
Console.ReadLine();
