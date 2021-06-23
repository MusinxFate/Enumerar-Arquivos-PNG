using System;
using System.IO;

namespace Enumerar_Arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
        tentarNovamente:
            Console.WriteLine("ATENÇÃO, O NOME DOS ARQUIVOS SERÁ ALTERADO ENUMERANDO-OS A PARTIR DE 0");
            Console.WriteLine("Insira o diretório onde deseja enumerar os arquivos");
            var diretorio = Console.ReadLine();
            if (diretorio.Length <= 0)
                goto tentarNovamente;
            try
            {
                var arquivos = Directory.GetFiles(diretorio);
                int counter = 0;

                foreach (var arquivo in arquivos)
                {
                    File.Move(arquivo, diretorio + "\\" + counter + ".png");
                    counter++;
                }
            }
            catch
            {
            tentarNovamente2:
                Console.WriteLine("\r\nNão foi possível encontrar o diretório especificado, deseja tentar novamente? (S/N)");
                var resposta = Console.ReadLine();
                if (resposta.Length != 1)
                {
                    Console.WriteLine("Por favor, insira \"S\" para Sim ou \"N\" para Não");
                    goto tentarNovamente2;
                }
                else
                {
                    if (resposta.ToLower() == "s")
                        goto tentarNovamente;
                    else if (resposta.ToLower() == "n")
                        return;
                    else
                    {
                        Console.WriteLine("Resposta Inválida\r");
                        goto tentarNovamente2;
                    }
                }
            }
        }
    }
}
