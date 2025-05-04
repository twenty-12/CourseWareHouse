using CourseWarehouse.Data;
using CourseWarehouse.Data.Entities;
using CourseWarehouse.Data.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseWarehouse.Services.HostedService
{
    public class InMemoryDataFillHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public InMemoryDataFillHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<InMemoryContext>();

            context.Tags.AddRange(new []
            {
                new Tag{Name = "C#", Category = TagCategory.Language},
                new Tag{Name = "Java", Category = TagCategory.Language},
                new Tag{Name = "Python", Category = TagCategory.Language},
                new Tag{Name = "JavaScript", Category = TagCategory.Language},
                new Tag{Name = "GoLang", Category = TagCategory.Language},
                new Tag{Name = "Jango", Category = TagCategory.Framework},
                new Tag{Name = "Spring", Category = TagCategory.Framework},
                new Tag{Name = "Docker", Category = TagCategory.Tool},
            });
            context.SaveChanges();
            
            var pythonTag = context.Tags.FirstOrDefault(t => t.Name == "Python");
            var javaTag = context.Tags.FirstOrDefault(t => t.Name == "Java");
            var goLangTag = context.Tags.FirstOrDefault(t => t.Name == "GoLang");
            var djangoTag = context.Tags.FirstOrDefault(t => t.Name == "Jango");
            var dockerTag = context.Tags.FirstOrDefault(t => t.Name == "Docker");
            
            context.Courses.AddRange(
                new Course
                {
                    Title = "Поколение Python: курс для начинающих",
                    Description = "Курс знакомит с основными типами данных, " +
                                  "конструкциями и принципами структурного программирования языка Python",
                    Url = "https://stepik.org/course/58852/info",
                    SkillLevel = SkillLevel.Beginner,
                    CourseTags = new List<CourseTag>
                    {
                        new CourseTag{ Tag = pythonTag}   
                    }
                },
                new Course
                {
                    Title = "Легкий старт в Java. Вводный курс для чайников",
                    Description = "Вводный курс по языку программирования Java. " +
                                  "Доступно изложенный материал и большое количество задач.\n\n",
                    Url = "https://stepik.org/course/90684/info",
                    SkillLevel = SkillLevel.Beginner,
                    CourseTags = new List<CourseTag>
                    {
                        new CourseTag{ Tag = javaTag}   
                    }
                },
                new Course
                {
                    Title = "Разработка веб-сервисов на Golang (Go)",
                    Description = "Для разработчиков с коммерческим опытом и студентов старших курсов " +
                                  "ИТ-специальностей. Для тех, кто пишет на PHP/Python/Ruby/JS (Node.js).",
                    Url = "https://stepik.org/course/187490/info",
                    SkillLevel = SkillLevel.Middle,
                    CourseTags = new List<CourseTag>
                    {
                        new CourseTag{ Tag = goLangTag}   
                    }
                },
                new Course
                {
                    Title = "Разработка бэкенд приложений на Django",
                    Description = "На данном курсе вы познакомитесь с разработкой бэкенд приложений на " +
                                  "django. В качестве итогового проекта предстанет приложение со своим API.",
                    Url = "https://stepik.org/course/155057/info",
                    SkillLevel = SkillLevel.Middle,
                    CourseTags = new List<CourseTag>
                    {
                        new CourseTag{ Tag = djangoTag},
                        new CourseTag{ Tag = pythonTag}
                    }
                },
                new Course
                {
                    Title = "Docker для начинающих + практический опыт",
                    Description = "Контейнеризация это MUST HAVE для DevOps. Пойми основные понятия Docker " +
                                  "и приобрети практический опыт прямо в своем браузере!",
                    Url = "https://stepik.org/course/123300/info",
                    SkillLevel = SkillLevel.Advanced,
                    CourseTags = new List<CourseTag>
                    {
                        new CourseTag{ Tag = dockerTag}   
                    }
                }
            );
            
            context.SaveChanges();
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}