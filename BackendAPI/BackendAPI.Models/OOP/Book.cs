using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Models.OOP
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual void PrintName(string? name)
        {
            Console.WriteLine(this.Title.ToString());

        }

        // hidden method
        public virtual void DisplayTitle()
        {
            Console.WriteLine($"{this.Title}");
        }

    }

    public class Chapter : Book
    {
        public Chapter(string title, int id)
        {
            this.Title = title;
            this.Id = id;
        }

        public override void PrintName(string? name){
            Console.WriteLine("Coming from override method: " + this.Title.ToString());
        }

        public new void DisplayTitle()
        {
            Console.WriteLine($"{this.Title.ToString()}");
        }
    }
}