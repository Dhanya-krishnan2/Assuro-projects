using System;
using System.Threading.Tasks;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Snapshooter.NUnit;
using ToDoApi.Data;
// as I added another field to delete the todo I need to make a test case for that 
// to  get the output successfully
namespace ToDoApi.Tests.ToDoItemTests
{
    public class DeleteToDoItemTests : BaseTest
    {
        [Test]
        public async Task CanDeleteNewItem()
        {
            // arrange
            var dbContext = Services
                .GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
                .CreateDbContext();
            var toDoItem = new ToDoItem
            {
                Content = "Make a cup of Tea",
                CreatedDate = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Status = ToDoItemStatus.PENDING,
                Priority = ToDoItemPriority.HIGH
            };
            dbContext.ToDoItems.Add(toDoItem);
            await dbContext.SaveChangesAsync();

            // act
            IExecutionResult result = await Services.ExecuteRequestAsync(
            QueryRequestBuilder.New()
                .SetQuery(@"
                        mutation($id: Uuid!){  
                          deleteToDoItem(input: {
                            id:$id
                              content: ""Make a cup of Tea""})
                              {       
                                toDoItem{
                                  id
                                  content
                                  status
                                  priority
                                  createdDate
                                    }
                                }
      
                            }")
                    .SetVariableValue("id", toDoItem.Id)
                     .Create());

            // assert
            result.MatchSnapshot(match => match
                .IgnoreField<Guid>("Data.deleteToDoItem.toDoItem.id")
                    .IgnoreField<DateTimeOffset>("Data.deleteToDoItem.toDoItem.createdDate")
                );
        }
    }
}
