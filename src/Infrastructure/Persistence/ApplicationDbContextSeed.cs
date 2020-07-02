using System.Collections.Generic;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var userList = new List<ApplicationUser>
            {
                new ApplicationUser {UserName = "administrator@localhost", Email = "administrator@localhost"},
                new ApplicationUser {UserName = "test1@localhost", Email = "test1@localhost"},
                new ApplicationUser {UserName = "test2@localhost", Email = "test2@localhost"}
            };

            foreach (var user in userList.Where(user => userManager.Users.All(u => u.UserName != user.UserName)))
            {
                await userManager.CreateAsync(user, "user123_!PW");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

                await context.SaveChangesAsync();
            }

            if (!context.NewsItems.Any())
            {
                var user1 = await userManager.FindByNameAsync("test1@localhost");
                var user2 = await userManager.FindByNameAsync("test2@localhost");

                context.NewsItems.Add(new NewsItem
                {
                    Title = "News Title 1",
                    Description = "Description 1",
                    Autor = user1.Id,
                    Comments =
                    {
                        new Comment {Text = "Comment 1", Autor = user1.Id},
                        new Comment {Text = "Comment 2", Autor = user2.Id},
                        new Comment {Text = "Comment 3", Autor = user1.Id},
                        new Comment {Text = "Comment 4", Autor = user2.Id},
                        new Comment {Text = "Comment 5", Autor = user1.Id},
                        new Comment {Text = "Comment 6", Autor = user1.Id},
                        new Comment {Text = "Comment 7", Autor = user1.Id},
                        new Comment {Text = "Comment 8", Autor = user2.Id},
                    }                                                       
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
