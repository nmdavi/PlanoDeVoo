using System;
using System.Collections.Generic;
using System.Data.Entity;
using static PlanoDeVoo.Models.PlanoModels;

namespace PlanoDeVoo.Models
{
    internal class DbInitialize : CreateDatabaseIfNotExists<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            List<Voo> voos = new List<Voo>()
            {
                new Voo(){NumeroVoo = "TAM1234", DataHorario = new DateTime(2020, 2, 28, 12, 30, 0, 0)},
                new Voo(){NumeroVoo = "AZU2222", DataHorario = new DateTime(2020, 2, 29, 08, 00, 0, 0) },
                new Voo(){NumeroVoo = "TAP3333", DataHorario = new DateTime(2020, 3, 01, 21, 10, 0, 0) }
            };

            List<Aeronave> aeronaves = new List<Aeronave>()
            {
                new Aeronave(){Matricula = "PT-1234" , Tipo = "A320"},
                new Aeronave(){Matricula = "PR-3333", Tipo = "A330"},
                new Aeronave(){Matricula = "PP-7777", Tipo = "A340"}
            };

            List<Aeroporto> aeroportos = new List<Aeroporto>()
            {
                new Aeroporto(){Nome = "", Sigla = "SBGR"},
                new Aeroporto(){Nome = "Aeroporto de São Paulo/Congonhas" , Sigla = "SBSP"},
                new Aeroporto(){Nome = "Aeroporto Internacional de Confins - Tancredo Neves" , Sigla = "SBCF"}
            };

            List<Plano> planos = new List<Plano>()
            {
                new Plano()
                {
                    FK_Voo = voos[0], 
                    FK_Aeronave = aeronaves[0], 
                    FK_Aeroporto = aeroportos[0]
                },

                new Plano()
                {
                   FK_Voo = voos[1],
                   FK_Aeronave = aeronaves[1],
                   FK_Aeroporto = aeroportos[1]
                },

                new Plano()
                {
                   FK_Voo = voos[2],
                   FK_Aeronave = aeronaves[2],
                   FK_Aeroporto = aeroportos[2]
                }
            };

            context.Planos.AddRange(planos);
            context.SaveChanges();
        }
    }
}