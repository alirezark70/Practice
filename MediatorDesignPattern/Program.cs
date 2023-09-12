// See https://aka.ms/new-console-template for more information

using MediatorDesignPattern;

ConcreteMediator concreteMediator = new ConcreteMediator();

ConcreteColleague1 c1 = new ConcreteColleague1(concreteMediator);

ConcreteColleague2 c2=new ConcreteColleague2(concreteMediator);

concreteMediator.Colleague1 = c1;
concreteMediator.Colleague2 = c2;

c1.Send("Colleague one");


Console.ReadLine();
