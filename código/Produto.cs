   using System;

namespace Doce_le.código
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public string? Sabor { get; set; }
        public string? Modelo { get; set; }

        public Produto() { }

        public Produto(int id, string nome, decimal preco, int quantidadeEmEstoque, string sabor, string modelo)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Sabor = sabor;
            Modelo = modelo;
        }
    }
}
