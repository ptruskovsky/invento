using Invento.Api.Data.Entities;

using System;

namespace Invento.Api.Data
{
    public static class DataSeed
    {
        public static void AddData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var ctx = scope.ServiceProvider.GetService<InventoDbContext>();

            var task1 = new Entities.Task
            {
                Id = 1,
                Name = "Task 1",
                Owner = "Pavel Truskovsky"
            };

            var task2 = new Entities.Task
            {
                Id = 2,
                Name = "Task 2",
                Owner = "User"
            };

            var task3 = new Entities.Task
            {
                Id = 3,
                Name = "Task 3",
                Owner = "User"
            };

            var task4 = new Entities.Task
            {
                Id = 4,
                Name = "Task 4",
                Owner = "User 2"
            };

            var task5 = new Entities.Task
            {
                Id = 5,
                Name = "Task 5",
                Owner = "User 2"
            };

            var project1 = new Project
            {
                Id = 1,
                Name = "Project 1",
                Owner = "Pavel Truskovsky",
            };

            var project2 = new Project
            {
                Id = 2,
                Name = "Project 2",
                Owner = "Pavel Truskovsky"
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

            ctx?.Add(project1);

            ctx?.Add(project2);

            ctx?.SaveChanges();
        }
    }
}
