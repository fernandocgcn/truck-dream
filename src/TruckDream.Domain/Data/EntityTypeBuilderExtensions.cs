using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using TruckDream.Domain.Entities;

namespace TruckDream.Domain.Data
{
    internal static class EntityTypeBuilderExtensions
    {
        /// <summary>
        /// source: https://www.volvotrucks.com.br/pt-br/news/blog/institucional/significado-nomes-dos-caminhoes.html
        /// </summary>
        /// <param name="builder"></param>
        public static void Seed(this EntityTypeBuilder<Model> builder)
        {
            var models = new List<Model>()
            {
                new Model
                {
                    Id = 1,
                    Acronym = "XH",
                    Name = "Extra Heavy / Extra Pesado"
                },
                new Model
                {
                    Id = 2,
                    Acronym = "N10",
                    Name = "Nose 10L / Bicudo 10L"
                },
                new Model
                {
                    Id = 3,
                    Acronym = "NL",
                    Name = "Nose Larger / Bicudo Cabine Mais Larga"
                },
                new Model
                {
                    Id = 4,
                    Acronym = "FH",
                    Name = "Frontal High / Frente Reta Cabine Alta"
                },
                new Model
                {
                    Id = 5,
                    Acronym = "FH16",
                    Name = "Frontal High 16L / Frente Reta Cabine Alta 16L"
                },
                new Model
                {
                    Id = 6,
                    Acronym = "VNL",
                    Name = "Volvo Nose Larger / Volvo Bicudo Cabine Mais Larga"
                },
                new Model
                {
                    Id = 7,
                    Acronym = "FL",
                    Name = "Frontal Lower / Frente Reta Cabine Mais Baixa"
                },
                new Model
                {
                    Id = 8,
                    Acronym = "FM",
                    Name = "Frontal Medium / Frente Reta Cabine Média"
                },
                new Model
                {
                    Id = 9,
                    Acronym = "FMX",
                    Name = "Frontal Medium Extreme / Frente Reta Cabine Média Fora da Estrada"
                },
                new Model
                {
                    Id = 10,
                    Acronym = "VM",
                    Name = "Volvo Medium 32T / Volvo Médio 32T"
                }
            };
            builder.HasData(models);
        }
    }
}
