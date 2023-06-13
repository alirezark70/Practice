// See https://aka.ms/new-console-template for more information
using Collections;


#region Dictionary
DictionarySample dictionarySample=new DictionarySample();
dictionarySample.CreateSampleList();

DictionaryEntitySample dictionaryEntitySample=new DictionaryEntitySample();
dictionaryEntitySample.AddToDictionary(1, new PersonModel { FirstName = "Alireza", LastName = "Rezaee" });


#endregion



#region SortedList
SortedListSample.TestTwo();
#endregion


#region Stack
StackSample.Start();

#endregion

#region Queue

QueueSample.Start();
#endregion



Person Person = new();
var result = Person.Personal();
List<Human> resultHuman = new();

//از اینترفیس زیر برای فقط خواندنی کردن لیست استفاده می کنیم
IReadOnlyList<Human> resultHuman2 = resultHuman.AsReadOnly();
resultHuman.EnsureCapacity(result.Count);

//وقتی ما یک لیست میسازیم سیستم پشت پرده یک آرایه میسازه با 4 خانه و برای هر بار بیشتر کردن 4 تای دیگه میسازه
//بهتره که تعداد به لیست بدیم
resultHuman.EnsureCapacity(result.Count);//این کد تعداد لیست به لیست میده
resultHuman.TrimExcess();//وقتی ما این را صدا میزنیم خانه های خالی را از رم سیستم حذف می کنه


Console.ReadLine();

