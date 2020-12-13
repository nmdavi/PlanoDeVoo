using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanoDeVoo.Models
{
    public class PlanoModels
    {
        public class Plano
        {
            [Key]
            public int Id { get; set; }

            public Voo FK_Voo { get; set; }
            public Aeronave FK_Aeronave { get; set; }
            public Aeroporto FK_Aeroporto { get; set; }

            //public Voo FK_Numero { get; set; }

            //public Voo FK_DataHorario { get; set; }

            //public Aeronave FK_Matricula { get; set; }

            //public Aeronave FK_Tipo { get; set; }

            //public Aeroporto AeroportoOrigem { get; set; }

            //public Aeroporto AeroportoDestino { get; set; }
        }

        public class Aeroporto
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [Column(TypeName = "varchar")]
            public string Nome { get; set; }

            [Required]
            [MaxLength(4)]
            [Column(TypeName = "char(4)")]
            [RegularExpression("[A-Za-z]")]
            public string Sigla { get; set; }
        }

        public class Aeronave
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(7)]
            [Column(TypeName = "char(7)")]
            [RegularExpression("[A-Za-z]{2}+-{1}+[0-9]{4}")]
            public string Matricula { get; set; }

            [Required]
            [MaxLength(4)]
            [Column(TypeName = "char(4)")]
            [RegularExpression("[A-Z]{1}+[0-9]{3}")]
            public string Tipo { get; set; }
        }

        public class Voo
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(7)]
            [Column(TypeName = "char(7)")]
            [RegularExpression("[A-Za-z]{3}+[0-9]{4}")]
            public string NumeroVoo { get; set; }

            [Required]
            public DateTime DataHorario { get; set; }
        }
    }
}
