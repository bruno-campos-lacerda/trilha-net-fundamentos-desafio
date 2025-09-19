using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            string modeloPlaca = @"^[A-Z]{3}-\d{4}$";
            bool valida = Regex.IsMatch(placa, modeloPlaca);

            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine($"A placa {placa} já está cadastrada");
            }
            else
            {
                if (valida)
                {
                    Console.WriteLine("Seja bem vindo!");
                    veiculos.Add(placa);
                    return;
                }
                Console.WriteLine("A placa deve seguir o seguinte modelo [LLL-NNNN]");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = "";
            placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;
                decimal valorTotal = 0;

                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoPorHora * horas + precoInicial;

                veiculos.Remove(placa);
                //Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {string.Format("{0:00}", valorTotal)}");
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R${valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++) {
                    Console.WriteLine($"{i + 1}. {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
