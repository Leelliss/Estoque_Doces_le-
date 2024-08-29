   using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Doce_le
{
    public class ControleEstoque
    {
        private List<Produto> estoque = new List<Produto>();
        private int contadorId = 1;
        private const string caminhoArquivo = "estoque.json";

        public ControleEstoque()
        {
            CarregarEstoque();
        }

        public void NovoProduto(string nome, decimal preco, int quantidadeEmEstoque, string sabor, string modelo)
        {
            Produto produto = new Produto(contadorId++, nome, preco, quantidadeEmEstoque, sabor, modelo);
            estoque.Add(produto);
            SalvarEstoque();
            Console.WriteLine("Produto adicionado com sucesso!");
        }

        public void RemoverProduto(int id)
        {
            var produto = estoque.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                estoque.Remove(produto);
                SalvarEstoque();
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        public void ListarProdutos()
        {
            if (estoque.Count == 0)
            {
                Console.WriteLine("Nenhum produto no estoque.");
                return;
            }

            foreach (var produto in estoque)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: R${produto.Preco}, Quantidade em Estoque: {produto.QuantidadeEmEstoque}, Sabor: {produto.Sabor}, Modelo: {produto.Modelo}");
            }
        }

        public void SalvarEstoque()
        {
            string jsonString = JsonSerializer.Serialize(estoque);
            File.WriteAllText(caminhoArquivo, jsonString);
        }

  public void EntradaEstoque(int id, int quantidade)
        {
            var produto = estoque.Find(p => p.Id == id);
            if (produto != null)
            {
                produto.QuantidadeEmEstoque += quantidade;
                SalvarEstoque();
                Console.WriteLine("Entrada de estoque realizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        public void SaidaEstoque(int id, int quantidade)
        {
            var produto = estoque.Find(p => p.Id == id);
            if (produto != null)
            {
                if (produto.QuantidadeEmEstoque >= quantidade)
                {
                    produto.QuantidadeEmEstoque -= quantidade;
                    SalvarEstoque();
                    Console.WriteLine("Saída de estoque realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Quantidade insuficiente em estoque.");
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
        public void CarregarEstoque()
        {
            if (File.Exists(caminhoArquivo))
            {
                string jsonString = File.ReadAllText(caminhoArquivo);
                estoque = JsonSerializer.Deserialize<List<Produto>>(jsonString) ?? new List<Produto>();
                contadorId = estoque.Count > 0 ? estoque.Max(p => p.Id) + 1 : 1;
            }
            
        }
        
    }
}
