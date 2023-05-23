using Invento.Api.Data.Entities;
using Invento.Api.DI.Context;

using System;

namespace Invento.Api.Data
{
    public static class DataSeed
    {
        public static void AddData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var factory = scope.ServiceProvider.GetRequiredService<IInventoDbContextFactory>();

            using var ctx = factory.CreateWrite();
                var task1 = new Entities.Task {
                    Id = "ac6184ed-fb1b-4d9b-97f6-a855b97d80dd",
                    Name = "Task 1",
                    Owner = "Pavel",
                    IsActive = true,
                };

                var task2 = new Entities.Task {
                    Id = "1fb68823-75f3-4aa2-81a7-a9451da53fa3",
                    Name = "Task 2",
                    Owner = "User",
                    IsActive = true,
                };

                var task3 = new Entities.Task {
                    Id = "c5fc120a-b450-4364-a881-a0cc98792f5c",
                    Name = "Task 3",
                    Owner = "User",
                    IsActive = true,
                };

                var task4 = new Entities.Task {
                    Id = "af3022b6-bf63-4ab4-a5f5-c000e31a3c99",
                    Name = "Task 4",
                    Owner = "User 2",
                    IsActive = true,
                };

                var task5 = new Entities.Task {
                    Id = "f24fd7f2-fd0f-42ba-9a28-2093d6f73f2a",
                    Name = "Task 5",
                    Owner = "User 2",
                    IsActive = true,
                };

                var project1 = new Project {
                    Id = "42082d48-6553-4ea3-913e-f7795eaa8072",
                    Name = "Project 1",
                    Owner = "Pavel",
                    IsActive = true,
                };

                var project2 = new Project {
                    Id ="60c5779a-7b84-46b9-84d0-33ae64951075",
                    Name = "Project 2",
                    Owner = "User",
                    IsActive = true,
                };

                var project1Tasks = new List<Entities.Task>
                {
                    task1,
                    task2,
                    task3,
                };

                var project2Tasks = new List<Entities.Task>
                {
                    task4,
                    task5
                };

                project1.Tasks = project1Tasks;

                project2.Tasks = project2Tasks;

                ctx.Projects.Add(project1);

                ctx.Projects.Add(project2);

                ctx.SaveChanges();
        }

            
    }
}
