﻿using System;

namespace Doce_le
{
    public class Program
    {
        static void Main(string[] args)
        {
            ControleEstoque estoque = new ControleEstoque();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Novo Produto");
                Console.WriteLine("2. Listar Produtos");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Entrada no estoque");
                Console.WriteLine("5. Saída do estoque");
                Console.WriteLine("0. Sair");

                int opcao = Convert.ToInt32(Console.ReadLine());
                 estoque.ListarProdutos();

                switch (opcao)
                {
                    case 1: //adicionar produto
                        Console.Write("Nome do Produto: ");
                        string nome = Console.ReadLine() ?? string.Empty;

                        Console.Write("Preço: ");
                        if (!Decimal.TryParse(Console.ReadLine(), out decimal preco))
                        {
                            Console.WriteLine("Formato inválido para preço.");
                            break;
                        }

                        Console.Write("Quantidade em Estoque: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int quantidade))
                        {
                            Console.WriteLine("Formato inválido para quantidade.");
                            break;
                        }

                        Console.Write("Sabor do Produto: ");
                        string sabor = Console.ReadLine() ?? string.Empty;

                        Console.Write("Modelo do Produto: ");
                        string modelo = Console.ReadLine() ?? string.Empty;

                        estoque.NovoProduto(nome, preco, quantidade, sabor, modelo);
                        break;

                        
                    case 2: //listar produtos
                        estoque.ListarProdutos();
                        break;

                    case 3: //remover produto
                        Console.Write("ID do Produto a Remover: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("Formato inválido para ID.");
                            break;
                        }
                        estoque.RemoverProduto(id);
                        break;
                    
                     case 4: // Entrada no estoque
                        Console.Write("ID do Produto para Entrada: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int idEntrada))
                        {
                            Console.WriteLine("Formato inválido para ID.");
                            break;
                        }

                        Console.Write("Quantidade a Adicionar: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int quantidadeEntrada))
                        {
                            Console.WriteLine("Formato inválido para quantidade.");
                            break;
                        }

                        estoque.EntradaEstoque(idEntrada, quantidadeEntrada);
                        break;

                    case 5:
                        // Saída do estoque
                        Console.Write("ID do Produto para Saída: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int idSaida))
                        {
                            Console.WriteLine("Formato inválido para ID.");
                            break;
                        }

                        Console.Write("Quantidade a Remover: ");
                        if (!Int32.TryParse(Console.ReadLine(), out int quantidadeSaida))
                        {
                            Console.WriteLine("Formato inválido para quantidade.");
                            break;
                        }

                        estoque.SaidaEstoque(idSaida, quantidadeSaida);
                        break;

                    case 0: //termina
                        continuar = false;
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("Lista de Produtos Atualizada:");
                    estoque.ListarProdutos();
                }

                Console.WriteLine();
            }
        }
    }
}
