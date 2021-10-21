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
            return authorRepo.Read(id);
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

        //Non-CRUD methods soon...
    }
}
