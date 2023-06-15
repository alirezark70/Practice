// See https://aka.ms/new-console-template for more information

using NutshelBool;

CSharpExample examp = new CSharpExample();

//examp.NondestructiveMutationForAnonymousypes();

examp.NewDeconstructionSyntax();

var logger = (IExampleLogger)examp;
logger.ExampleLog("Test");
Console.ReadLine();
