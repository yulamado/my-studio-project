using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using MyStudioProject.Models;

namespace MyStudioProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure Stephen (IsAdmin)
            var Yul = await userManager.FindByNameAsync("Yul.Amado@CoderCamps.com");
            if (Yul == null)
            {
                // create user
                Yul = new ApplicationUser
                {
                    UserName = "Yul.Amado@CoderCamps.com",
                    Email = "Yul.Amado@CoderCamps.com",
                    FullName = "Yul"
                };
                await userManager.CreateAsync(Yul, "Yul123!");

                // add claims
                await userManager.AddClaimAsync(Yul, new Claim("IsAdmin", "true"));
            }


            var Marylin = await userManager.FindByNameAsync("Marylin@dance.com");
            if (Marylin == null)
            {

                Marylin = new ApplicationUser
                {
                    UserName = "Marylin@dance.com",
                    Email = "Marylin@dance.com",
                    FullName = "Marylin"
                };
                await userManager.CreateAsync(Marylin, "Marylin123!");
            }

            var Daniel = await userManager.FindByNameAsync("Daniel@dance.com");
            if (Daniel == null)
            {

                Daniel = new ApplicationUser
                {
                    UserName = "Daniel@dance.com",
                    Email = "Daniel@dance.com",
                    FullName = "Daniel"
                };
                await userManager.CreateAsync(Daniel, "Daniel123!");
            }

            var Monica = await userManager.FindByNameAsync("Monica@dance.com");
            if (Monica == null)
            {

                Monica = new ApplicationUser
                {
                    UserName = "Monica@dance.com",
                    Email = "Monica@dance.com",
                    FullName = "Monica"
                };
                await userManager.CreateAsync(Monica, "Monica123!");
            }

            var Julian = await userManager.FindByNameAsync("Julian@dance.com");
            if (Julian == null)
            {

                Julian = new ApplicationUser
                {
                    UserName = "Julian@dance.com",
                    Email = "Julian@dance.com",
                    FullName = "Julian"
                };
                await userManager.CreateAsync(Julian, "Julian123!");
            }

            var Bachata = new Rhythm { Name = "Bachata" };
            var Salsa = new Rhythm { Name = "Salsa" };
            var Kizomba = new Rhythm { Name = "Kizomba" };
            if (!context.Rhythms.Any())
            {
                context.Rhythms.AddRange(Bachata, Salsa, Kizomba);
                context.SaveChanges();
            }

            var Dennis = new Student { FirstName = "Dennis", LastName = "Arce", Hour = "9:00 a.m", Room = "3", Rhythm = Bachata, Instructor = Marylin };
            var Richy = new Student { FirstName = "Richy", LastName = "Plitz", Hour = "10:00 a.m", Room = "2", Rhythm = Salsa, Instructor = Marylin };
            var Linda = new Student { FirstName = "Linda", LastName = "Razo", Hour = "11:00 a.m", Room = "1", Rhythm = Kizomba, Instructor = Marylin };
            var Joel = new Student { FirstName = "Joel", LastName = "Duncan", Hour = "12:00 a.m", Room = "2", Rhythm = Bachata, Instructor = Marylin };
            var Andy = new Student { FirstName = "Andy", LastName = "Young", Hour = "1 p.m", Room = "2", Rhythm = Salsa, Instructor = Daniel };
            var Todd = new Student { FirstName = "Todd", LastName = "Morril", Hour = "2:00 p.m", Room = "1", Rhythm = Salsa, Instructor = Daniel };
            var Brian = new Student { FirstName = "Brian", LastName = "Escola", Hour = "3:00 p.m", Room = "1", Rhythm = Kizomba, Instructor = Daniel };
            var Hannah = new Student { FirstName = "Hannah", LastName = "Nicol", Hour = "4:00 p.m", Room = "2", Rhythm = Bachata, Instructor = Daniel };
            var Betsi = new Student { FirstName = "Betsi", LastName = "Pinkus", Hour = "5:00 p.m", Room = "3", Rhythm = Salsa, Instructor = Julian };
            var Cindy = new Student { FirstName = "Cindy", LastName = "Velez", Hour = "6:00 p.m", Room = "3", Rhythm = Kizomba, Instructor = Julian };
            var Maria = new Student { FirstName = "Maria", LastName = "Salazar", Hour = "7:00 p.m", Room = "1", Rhythm = Bachata, Instructor = Julian };
            var Nicole = new Student { FirstName = "Nicole", LastName = "Sierra", Hour = "8:00 p.m", Room = "3", Rhythm = Bachata, Instructor = Julian };
            var Alex = new Student { FirstName = "Alex", LastName = "Dorgh", Hour = "9:00 a.m", Room = "2", Rhythm = Salsa, Instructor = Monica };
            var Patricia = new Student { FirstName = "Patricia", LastName = "Dinen", Hour = "10:00 a.m", Room = "2", Rhythm = Kizomba, Instructor = Monica };
            var Patrick = new Student { FirstName = "Patrick", LastName = "Quinn", Hour = "11:00 a.m", Room = "1", Rhythm = Bachata, Instructor = Monica };
            var Grisell = new Student { FirstName = "grisell", LastName = "Paz", Hour = "12:00 a.m", Room = "3", Rhythm = Bachata, Instructor = Monica };
            var Lucas = new Student { FirstName = "Lucas", LastName = "Costa", Hour = "1:00 p.m", Room = "2", Rhythm = Salsa, Instructor = Monica };

            if (!context.Students.Any())
            {
                context.Students.AddRange(Lucas, Grisell, Patricia, Patrick, Alex, Nicole, Maria, Cindy, Betsi, Hannah, Brian, Todd, Andy, Joel, Linda, Richy, Dennis);
                context.SaveChanges();
            }
            if (!context.InstructorStudents.Any())
            {
                context.InstructorStudents.AddRange(
                new InstructorStudent
                {
                    InstructorId = Marylin.Id,
                    StudentId = Dennis.Id
                },
                 new InstructorStudent
                 {
                     InstructorId = Marylin.Id,
                     StudentId = Richy.Id
                 },
                 new InstructorStudent
                 {
                     InstructorId = Marylin.Id,
                     StudentId = Joel.Id
                 },
                  new InstructorStudent
                  {
                      InstructorId = Marylin.Id,
                      StudentId = Linda.Id
                  },
                  new InstructorStudent
                  {
                      InstructorId = Daniel.Id,
                      StudentId = Andy.Id
                  },
                 new InstructorStudent
                 {
                     InstructorId = Daniel.Id,
                     StudentId = Todd.Id
                 },
                 new InstructorStudent
                 {
                     InstructorId = Daniel.Id,
                     StudentId = Brian.Id
                 },
                  new InstructorStudent
                  {
                      InstructorId = Daniel.Id,
                      StudentId = Hannah.Id
                  },
                    new InstructorStudent
                    {
                        InstructorId = Julian.Id,
                        StudentId = Betsi.Id
                    },
                 new InstructorStudent
                 {
                     InstructorId = Julian.Id,
                     StudentId = Cindy.Id
                 },
                 new InstructorStudent
                 {
                     InstructorId = Julian.Id,
                     StudentId = Maria.Id
                 },
                  new InstructorStudent
                  {
                      InstructorId = Julian.Id,
                      StudentId = Nicole.Id
                  },
                   new InstructorStudent
                   {
                       InstructorId = Monica.Id,
                       StudentId = Alex.Id
                   },
                 new InstructorStudent
                 {
                     InstructorId = Monica.Id,
                     StudentId = Patricia.Id
                 },
                 new InstructorStudent
                 {
                     InstructorId = Monica.Id,
                     StudentId = Patrick.Id
                 },
                  new InstructorStudent
                  {
                      InstructorId = Monica.Id,
                      StudentId = Grisell.Id
                  },
                  new InstructorStudent
                  {
                      InstructorId = Monica.Id,
                      StudentId = Lucas.Id
                  });


                context.SaveChanges();



            }
        }
    }
}
            


       
