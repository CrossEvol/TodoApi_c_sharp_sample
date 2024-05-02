namespace TodoApi.Data
{
    public class DbInitializer
    {
        public static void Initialize(TodoGroupDbContext context)
        {
            if (context.Todos.Any())
            {
                return;
            }

            var todos = new Todo[] {
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5) },
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                        new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5) },
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
                new Todo {Title = new Bogus.DataSets.Hacker().Noun(),Description = new Bogus.DataSets.Lorem("en").Sentence(5)},
        };
            context.Todos.AddRange(todos);
            context.SaveChanges();
        }
    }
}
