using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacaoCompraFazenda
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repetir = true; // Declaração de uma variável booleana 'repetir', inicializada como true, para controlar o loop de repetição.

            while (repetir) // Início de um loop 'while' que continuará enquanto 'repetir' for true.
            {
                Console.Clear(); // Limpa a tela do console para tornar a saída mais legível.
                Console.WriteLine("Simulação de Compra de Fazenda Dividida por Hectares"); 
                Console.WriteLine(); 
                Console.WriteLine("OBSERVE AS ORIENTAÇÕES ABAIXO:"); 
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
                
                Console.WriteLine("A FAZENDA ESTÁ SENDO VENDIDA DA SEGUINTE FORMA:"); 
                Console.WriteLine(); 
                Console.WriteLine("Ela possui 500 hectares, 1º quarto dela tem o valor do hectare de R$ 5000,00 reais."); 
                Console.WriteLine("O 2º quarto dela foi avaliado em R$ 7500,00 reais e metade da fazenda tem o valor avaliado em R$ 3800,00 reais."); 
                Console.WriteLine("Se o comprador pagar à vista ganha 8 % de desconto, se escolher pagar a prazo, ele poderá dividir em até 60 parcelas");
                
                Console.WriteLine("tendo juros compostos de 0,8 % ao mês."); 
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
                
                Console.WriteLine("SITUAÇÃO DE FINANCIAMENTO:"); 
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
                
                Console.WriteLine("Qual parte da propriedade você deseja comprar?"); 
                Console.WriteLine(); 
                Console.WriteLine("Primeiro quarto de 125 hectares aperte [1]?"); 
                Console.WriteLine("Segundo quarto de 125 hectares aperte [2]?"); 
                Console.WriteLine("Metade de 250 hectares aperte [3]?"); 
                Console.WriteLine("Toda a fazenda de 500 hectares aperte [4]?");
                Console.WriteLine(); 
                Console.Write("Digite aqui: "); 

                int opcaoCompra = int.Parse(Console.ReadLine()); // Lê a entrada do usuário, converte para inteiro e armazena em 'opcaoCompra'.
                double valorHectare = 0; // Inicializa a variável 'valorHectare' com 0.
                int hectares = 0; // Inicializa a variável 'hectares' com 0.

                switch (opcaoCompra) // Início do switch case para determinar o valor por hectare e o número de hectares.
                {
                    case 1:
                        valorHectare = 5000; // Se a opção for 1, o valor por hectare é 5000.
                        hectares = 125; // E o número de hectares é 125.
                        break;
                    case 2:
                        valorHectare = 7500; // Se a opção for 2, o valor por hectare é 7500.
                        hectares = 125; // E o número de hectares é 125.
                        break;
                    case 3:
                        valorHectare = 3800; // Se a opção for 3, o valor por hectare é 3800.
                        hectares = 250; // E o número de hectares é 250.
                        break;
                    case 4:
                        valorHectare = (5000 + 7500 + 3800) / 3; // Se a opção for 4, calcula a média dos valores por hectare.
                        hectares = 500; // E o número de hectares é 500.
                        break;
                    default:
                        Console.WriteLine("Opção inválida!"); // Se nenhuma das opções acima for selecionada, exibe uma mensagem de erro.
                        continue; // Volta para o início do loop.
                }

                double valorTotal = valorHectare * hectares; // Calcula o valor total da compra.
                Console.WriteLine($"O valor total da compra é: R$ {valorTotal:F2}"); // Exibe o valor total da compra formatado.

                Console.WriteLine("Escolha a forma de pagamento:"); 
                Console.WriteLine("1 - À vista (desconto de 8%)"); 
                Console.WriteLine("2 - A prazo (juros compostos de 0,8% ao mês)"); 
                Console.Write("Digite aqui: "); 
                int opcaoPagamento = int.Parse(Console.ReadLine()); // Lê a entrada do usuário, converte para inteiro e armazena em 'opcaoPagamento'.

                if (opcaoPagamento == 1) // Se a opção de pagamento for 1 (à vista):
                {
                    valorTotal -= valorTotal * 0.08; // Aplica um desconto de 8% ao valor total.
                    Console.WriteLine($"Valor final com desconto à vista: R$ {valorTotal:F2}"); // Exibe o valor final com desconto formatado.
                }
                else if (opcaoPagamento == 2) // Se a opção de pagamento for 2 (a prazo):
                {
                    Console.Write("Digite o número de parcelas (máximo 60): "); 
                    int numeroParcelas = int.Parse(Console.ReadLine()); // Lê a entrada do usuário, converte para inteiro e armazena em 'numeroParcelas'.
                    while (numeroParcelas < 1 || numeroParcelas > 60) // Início de um loop para validar o número de parcelas.
                    {
                        Console.WriteLine("Número de parcelas inválido! Digite um valor entre 1 e 60."); 
                        Console.Write("Digite o número de parcelas (máximo 60): "); 
                        numeroParcelas = int.Parse(Console.ReadLine()); // Lê a entrada do usuário novamente.
                    }

                    double jurosMensal = 0.008; // Define a taxa de juros mensal de 0,8%.
                    double valorParcela = valorTotal * Math.Pow(1 + jurosMensal, numeroParcelas) / numeroParcelas; // Calcula o valor de cada parcela.
                    double valorFinal = valorParcela * numeroParcelas; // Calcula o valor final com juros.

                    Console.WriteLine($"Valor final com juros a prazo: R$ {valorFinal:F2}"); // Exibe o valor final com juros formatado.
                    Console.WriteLine($"Valor de cada parcela ({numeroParcelas}x): R$ {valorParcela:F2}"); // Exibe o valor de cada parcela formatado.
                }
                else // Se nenhuma das opções de pagamento for válida:
                {
                    Console.WriteLine("Opção de pagamento inválida!"); // Exibe uma mensagem de erro.
                    continue; // Volta para o início do loop.
                }

                Console.WriteLine(); // Exibe uma linha em branco para espaçamento.
                Console.WriteLine("Deseja repetir o exercício? (s/n)"); 
                char resposta = char.ToLower(Console.ReadKey().KeyChar); // Lê a resposta do usuário, converte para minúscula.
                repetir = resposta == 's'; // Define 'repetir' como true se a resposta for 's', caso contrário, false.
            
            Console.ReadKey();
            }
        }
    }
}

//A função Math.Pow() em C# é usada para elevar um número (base) a uma determinada potência (exponente).
//A assinatura da função é Math.Pow(double base, double exponente), onde:

//    base: é o número que você quer elevar a uma potência.
//    exponente: é a potência à qual a base será elevada.

//No contexto do seu código, a expressão Math.Pow(1 + jurosMensal, numeroParcelas) faz o seguinte:

//    (1 + jurosMensal): Primeiro, soma-se 1 ao valor de jurosMensal (que representa a taxa de juros mensal como um decimal,
//    por exemplo, 0,008 para 0,8%).

//    Math.Pow(...): Em seguida, eleva-se o resultado dessa soma à potência de numeroParcelas.
//    Isso calcula o fator de juros composto aplicado ao longo de numeroParcelas meses.

//    valorTotal * ... / numeroParcelas: Finalmente, multiplica-se o valorTotal pelo resultado obtido de Math.Pow()
//    e divide-se pelo numeroParcelas. Isso calcula o valor de cada parcela mensal considerando os juros compostos.

//Portanto, o código calcula o valor de cada parcela de um financiamento,
//considerando juros compostos ao longo de um certo número de parcelas.