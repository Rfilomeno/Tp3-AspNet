using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Data.EntitiesConfig
{
    public class BookConfig : EntityTypeConfiguration<Book>
    {
        public BookConfig()
        {
            //para forçar o nome da tabela
            //ToTable("Book");

            //para forçar a chave primaria
            //HasKey(b => b.BookId);

            Property(b => b.Titulo).HasMaxLength(150).IsRequired();
            Property(b => b.Isbn).IsRequired();
            

        }
    }
    
}
