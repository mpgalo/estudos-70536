using System;
using System.Collections.Generic;
using System.Text;
using RendimentoEscolar;

namespace TesteRendimentoEscolar
{
    class Teste
    {
        static void Main(string[] args)
        {
            Rendimento r = new Rendimento();

            Console.Write("Matricula: ");
            r.Matricula = Console.ReadLine();
            Console.Write("Aluno: ");
            r.Aluno = Console.ReadLine();
            Console.Write("Matéria: ");
            r.Materia = Console.ReadLine();
            try
            {
                Console.Write(" Nota 1: ");
                r.Nota1b = decimal.Parse(Console.ReadLine());
                Console.Write(" Nota 2: ");
                r.Nota2b = decimal.Parse(Console.ReadLine());
                Console.Write(" Nota 3: ");
                r.Nota3b = decimal.Parse(Console.ReadLine());
                Console.Write(" Nota 4: ");
                r.Nota4b = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Média final (média aritmética simples): {0}", r.MediaFinal);

                r.CalcularMediaFinal += delegate(decimal nota1b, decimal nota2b, decimal nota3b, decimal nota4b)
        {
            return (nota1b + nota2b * 2 + nota3b * 3 + nota4b * 4) / 10;
        };

                Console.WriteLine("Média final (média ponderada com pesos 1,2,3,4: {0}", r.MediaFinal);

             
            }
            catch (FormatException)
            {
                Console.Write("Problema na conversão da nota.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: \"{0}\".", ex.Message);
            }
        }
       
    }
}
