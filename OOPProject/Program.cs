// See https://aka.ms/new-console-template for more information
using OOPProject;

VirtualMethodClass parent = new();

VirtualClassChild child= new();

var result=parent.GetFullName("Alireza","Rezaee");
var result2 = child.GetFullName("Alireza", "Rezaee");

Console.ReadLine();