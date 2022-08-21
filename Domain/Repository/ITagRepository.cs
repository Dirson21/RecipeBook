using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositoy
{
    public interface ITagRepository
    {
        List<Tag> GetAll();

        Tag GetById(int tagId);

        Tag GetByName(string name);

    }
}
