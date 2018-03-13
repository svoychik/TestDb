namespace WebApplication2.Content
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication2.Content.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Puzzle> Puzzles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
    public abstract class BaseModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
    }
    public class Board: BaseModel
    {
        public int MyProperty { get; set; }
        public int Wins { get; set; }
        public string Motiv { get; set; }
        public string U1 { get; set; }
        public string U2 { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Pgn { get; set; }
    }

    public class Message : BaseModel
    {
        public string Body { get; set; }
        public string Send { get; set; }
        public virtual User Receiver { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
    }

    public class Puzzle : BaseModel
    {
        public string Type { get; set; }
        public virtual User CreatedBy { get; set; }
        public string FeInit { get; set; }
        public string Fenfinish { get; set; }
        public string Nummoves { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Corrects { get; set; }
        public int Intents { get; set; }

    }

    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Role { get; set; }
        public string ConvAviertas { get; set; }
        public string Array { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }


}