using System;
using System.Collections.Generic;
using Hospedagem.Models;

namespace Hospedagem
{
    class Program
    {
        Dictionary<string,Pessoa> pessoas = new Dictionary<string, Pessoa>();
        Dictionary<int, Suite> suites = new Dictionary<int, Suite>();
        Dictionary<int, Reserva> reservas = new Dictionary<int, Reserva>();
        Program program ;
        static void Main(string[] args)
        {
            Console.WriteLine("Olá bem vindo ao Hotel Miksza's\n\n");
            
            Program program = new Program();
            program.Menu();


        }
        public string MontaMenu()
        {
            Console.WriteLine("Qual ação deseja fazer ?");
            Console.WriteLine($"1 - Cadastrar Hospedes.\n" +
                               $"2 - Cadastrar Suite.\n" +
                               $"3 - Alocar Suite.\n" +
                               $"4 - Mostrar Hospedes.\n" +
                               $"5 - Mostrar Suites.");
           
            return Console.ReadLine().ToString();
        }
        public void Menu()
        {
            program = new Program();
            string resp = string.Empty;
            bool i = true;
            
            while (i == true)
            { try
                {
                    Console.Clear();
                    resp = program.MontaMenu();
                    switch (resp)
                    {
                        case "1": { program.CadastrarHospedes();
                                break; }
                        case "2": { program.CadastrarSuite(); break; }
                        case "3": { program.AlocarSuite(); break; }
                        case "4": { program.MostrarHospedes(); break; }
                        case "5": { program.MostrarSuite(); break; }
                        case "6": { break; }
                        case "7": { break; }
                    }

                    Console.Clear();
                   


                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Ocorreu um erro {e.Message} quer continuar ?");
                    i = Console.ReadLine().ToString().ToLower() == "y" ? true : false;
                }
                
            }
        }

        public void CadastrarHospedes()
        {
            try {

                bool resp = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"CADASTRO DE HOSPEDES");
                    Pessoa pessoa = new Pessoa();

                    Console.WriteLine("CPF ? ");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("Nome ? ");
                    pessoa.Nome = Console.ReadLine();

                    Console.WriteLine("Sobre Nome ? ");
                    pessoa.SobreNome = Console.ReadLine();

                    pessoas.Add(cpf, pessoa);
                    Console.WriteLine($"Hoespede {pessoa.Nome} {pessoa.SobreNome} cadastrados com Sucesso!\n");

                    Console.WriteLine("Quer Cadasdtrar mais um Hospede ? Y/N");
                    resp = Console.ReadLine().ToString().ToLower() == "y" ? true : false;


                } while (resp == true);
                

            }
            catch (Exception e) { }
            

        }
        public Pessoa MostrarHospedes()
        {
            Console.WriteLine("Digite o CPF ? ");
            string cpf = Console.ReadLine();
            bool i = true;
            while (i)
            {
                if (pessoas.ContainsKey(cpf))
                {
                    Console.WriteLine($"Hospede: {pessoas[cpf].Nome} {pessoas[cpf].SobreNome}.");
                    Console.ReadLine();
                    return pessoas[cpf];
                }
                else
                {
                    Console.WriteLine($"Não contem nenhum hospede com o CPF{cpf}, Tente outro ou digite 'Sair'");
                    cpf = Console.ReadLine();
                    i = cpf.ToLower() == "sair" ? false : true;
                }
                
            }
            return null;
        }
        public void CadastrarSuite()
        {
            

                bool resp = true;
                do
            {
                try
                { 
                    Console.Clear();
                    Console.WriteLine($"CADASTRO DE SUITES");
                    Suite suite = new Suite();


                    Console.WriteLine("Numero da Suite ? ");
                    suite.Numero  = ValidaSuite();

                    Console.WriteLine("Tipo da Suite.\n(1)Casal\n(2)Solteiro");
                    suite.Tipo = Convert.ToInt32(Console.ReadLine()) == 1? Suites.Casal.ToString():Suites.Solteiro.ToString();

                    Console.WriteLine("Capacidade ? ");
                    suite.Capacidade = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Valor ? ");
                    suite.Valor = Convert.ToDecimal(Console.ReadLine());

                    suites.Add(suite.Numero, suite);
                    Console.WriteLine($"Suite {suite.Numero}, cadastrados com Sucesso!\n");

                    Console.WriteLine("Quer Cadasdtrar mais uma suite ? Y/N");
                    resp = Console.ReadLine().ToString().ToLower() == "y";
                
                }
                catch (Exception)
                { 
                    Console.WriteLine("Ocorreu um erro na Execução quer tentar de novo.Y/N");
                    resp = Console.ReadLine().ToString().ToLower() == "y";
                }

            } while (resp == true);


           
        }
        public int ValidaSuite()
        {
            
            int num = Convert.ToInt32(Console.ReadLine());
            bool i = true;
            while (i)
            {
                if (suites.ContainsKey(num))
                {
                    Console.WriteLine($"A suite {num} ja esta cadastrada, mude para outro numero, (Susjestão {num+1})");
                    num = Convert.ToInt32(Console.ReadLine());
                    
                }
                else { i = false; }
            }
            
            
            return num;
        }
        
        public enum Suites
        {
            Casal = 1,
            Solteiro = 2

        }
        public Suite MostrarSuite()
        {
            Console.WriteLine("Digite o Numero da Suite ? ");
            int num = Convert.ToInt32(Console.ReadLine());
            bool i = true;
            while (i)
            {
                if (suites.ContainsKey(num))
                {
                    Console.WriteLine($"A Suite Numero {num}:\n Tipo {suites[num].Tipo}\nCapacide para {suites[num].Capacidade}\nValor de {suites[num].Valor}.");
                    Console.ReadLine();
                    return suites[num];
                }
                else
                {
                    Console.WriteLine($"Não a Suite com Numero {num}");
                    Console.WriteLine($"Não contem nenhuma Suite com o numero {num}, Tente outro");
                    num =  Convert.ToInt32(Console.ReadLine());
                    
                }
               i = Console.ReadLine().ToLower() == "sair" ? false : true;
            }
            return null;
        }
        public void AlocarSuite()
        {
            Console.Clear();
            Console.WriteLine("ALOCAÇÃO DE SUITES\n\n");
            Reserva reserva = new Reserva();
            bool i = true;
            while (i)
            {
                try {
                    Console.WriteLine("Qual Suite voce quer locar?");
                    Suite suite = MostrarSuite();
                    Console.WriteLine("Para Qual cliente deseja Locar?");
                    List<Pessoa> pessoa = new List<Pessoa>();
                    pessoa.Add(MostrarHospedes());



                    reserva.suite = suite;
                    reserva.Hospedes.Add(pessoa[0]);
                    reserva = CalcularValor(reserva);
                    int id = GerarIdReserva();
                    

                    ConfirmaLocacao(reserva);
                    reservas.Add(id, reserva);
                    i = false;


                }
                catch(Exception e) {
                    Console.WriteLine("Ocorreu um erro na Execução quer tentar de novo.Y/N");
                    i = Console.ReadLine().ToString().ToLower() == "y";
                }

            }
        }
       public int GerarIdReserva()
        {
            for(int i = 1;i < 1500; i++)
            {
                if (!reservas.ContainsKey(i)) return i;
            }
            return 0;
        }
        public Reserva CalcularValor(Reserva reserva)
        {
            Console.WriteLine("Por quantos Dias sera feito a reserva da suite?");
            int dias = Convert.ToInt32(Console.ReadLine());
            decimal valorRerserva = dias *  reserva.suite.Valor;
            decimal valorDesonto = valorRerserva - (valorRerserva * Convert.ToDecimal(0.15));
            decimal valorFinal = dias > 5 ? valorDesonto : valorRerserva;
            Console.WriteLine($"A Suite {reserva.suite.Numero} esta no valor de {string.Format("{0:0,0.00}", reserva.suite.Valor) } a Diaria, fazendo a locação por {dias} Dias fica no Valor de R${string.Format("{0:0,0.00}", valorRerserva) }");
            if (dias >= 5)
            {
                Console.WriteLine($"Mas Com a promoção para locação acima de 5 dias sera aplicado 5% de desconto ficando no valor de R${string.Format("{0:0,0.00}", valorDesonto)}");
            }
            Console.ReadLine();
            Console.ReadLine();
            reserva.valor = valorFinal;
            reserva.dias = dias;
            return reserva;
        }
        public bool ConfirmaLocacao(Reserva reserva)
        {
            Console.WriteLine($"Voce Confirma a Locação da suite { reserva.suite.Numero}, Para {reserva.Hospedes[0].Nome} {reserva.Hospedes[0].SobreNome}, por R${string.Format("{0:0,0.00}", reserva.valor)} por {reserva.dias} dias");
            Console.WriteLine($"Voce confirma? Y/N");
            string a = Console.ReadLine().ToLower();
            return true;
            //if(a == "N")
            //{
            //     Console.WriteLine($"O que deseja Mudar?\n" +
            //        $"1 - Suite: {reserva.suite.Numero}" +
            //        $"2 - Hospedes:{reserva.Hospedes[0].Nome} {reserva.Hospedes[0].SobreNome}" +
            //        $"3 - Dias{reserva.dias}");
            //    switch (Console.ReadLine())
            //    {
            //        case "1": { break; }
            //        case "1": { break; }
            //        case "1": { break; }
            //    }
            //}

        }
    }
}
