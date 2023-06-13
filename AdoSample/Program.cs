// See https://aka.ms/new-console-template for more information


using AdoSample;
using AdoSample.Models;



SqlBulkSample bulkSample = new SqlBulkSample();

bulkSample.AddBulk();

var reader = new TransactionalSample();


//ConnectionWrapper ConnectionWrapper = new ConnectionWrapper();
//ConnectionWrapper.WorkingWithDataReader<Categories>($"{nameof(Categories.CategoryName)} IS NOT NULL","Id");