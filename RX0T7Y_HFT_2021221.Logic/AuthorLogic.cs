using RX0T7Y_HFT_2021221.Models;
using RX0T7Y_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RX0T7Y_HFT_2021221.Logic
{
    public class AuthorLogic
    {
        IAuthorRepository authorRepo;

        public AuthorLogic(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        //CRUD methods

        public void Create(Author author)
        {
            if (author.YearOfBirth <= 0)
            {
                throw new ArgumentException("Impossible data!!");
            }
            authorRepo.Create(author);
        }

        public Author Read(int id)
        {
            if (id >= 0)
            {
                return authorRepo.Read(id);
            }
            else
            {
                throw new ArgumentException("Impossible data");
            }
        }

        public IEnumerable<Author> ReadAll()
        {
            return authorRepo.ReadAll();
        }

        public void Delete(int id)
        {
            authorRepo.Delete(id);
        }

        public void Update(Author author)
        {
            authorRepo.Update(author);
        }

        //--------------------

        public IEnumerable<object> GroupbyPublisher()
        {
            var q = from x in authorRepo.ReadAll()
                    group x by x.Publisher.Name into g
                    select new
                    {
                        Name = g.Key,
                        Count = g.Count()
                    };
            return q;
        }
        public IEnumerable<object> GroupbyHeadquarters()
        {
            var q = from x in authorRepo.ReadAll()
                    group x by x.Publisher.Headquarters into g
                    select new
                    {
                        Name = g.Key,
                        Count = g.Count()
                    };
            return q;
        }



        public double AVGPrice()
        {
            var q = Math.Round(authorRepo.ReadAll()
                .SelectMany(t => t.Publisher.Books).Average(a => a.Price),0);

            return q;
        }
    }
}
