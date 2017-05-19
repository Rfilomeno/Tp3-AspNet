using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp3_AspNet.Domain.Entities;

namespace Tp3_AspNet.Data.EntitiesConfig
{
    public class AuthorConfig : EntityTypeConfiguration<Author>
    {
        public AuthorConfig()
        {
            //para forçar o nome da tabela
            //ToTable("Author");

            //para forçar a chave primaria
            //HasKey(a => a.AuthorId);

            Property(a => a.FirstName).HasMaxLength(150).IsRequired();
            Property(a => a.LastName).HasMaxLength(150).IsRequired();
        
            HasMany(a => a.Books).WithMany(b => b.Authors)
            .Map(m =>
            {
                m.MapLeftKey("AuthorId");
                m.MapRightKey("BookId");
                m.ToTable("AuthorBook");
            });

        }
    }
   
}
