namespace ToDoNow.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToDoNow.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoNow.Models.ToDoNowDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ToDoNow.Models.ToDoNowDb";
        }

        protected override void Seed(ToDoNow.Models.ToDoNowDb context)
        {

            context.Todos.AddOrUpdate(
                    new Todo { Title = "Learn C#", Body = "Learn everything about C#", Completed = false },
                    new Todo { Title = "Learn ASP Net", Body = "Learn everything about asp net and creating web apps", Completed = false },
                    new Todo { Title = "Learn UWP", Body = "Learn everything about creating UWP applications", Completed = false }

                );
         
        }
    }
}
