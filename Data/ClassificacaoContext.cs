using Classificacao_F1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classificacao_F1.Data
{
    public class ClassificacaoContext : DbContext
    {
        public ClassificacaoContext(DbContextOptions<ClassificacaoContext> options)
            : base(options)
        {
        }

        public DbSet<Resultado> Resultado { get; set; }
    }
}
