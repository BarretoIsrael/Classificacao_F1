using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Classificacao_F1.Models
{
    public class Resultado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Equipe { get; set; }
        [Range(typeof(int), minimum:"1", maximum: "5")]
        public int Posicao_Grid { get; set; }
        public int Pontuacão { get; set; }
    }
}
