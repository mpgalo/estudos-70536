using System;
using System.Collections.Generic;
using System.Text;
using AgendaContatos;

namespace TesteAgendaContaos
{
    class Program
    {
        private Agenda agenda;

        private Program(Agenda agenda)
        {
            this.agenda = agenda;
        }

        static void Main(string[] args)
        {
            Contato c1 = new Contato();
            c1.Tipo = TipoContato.Familia;
            c1.Nome = "Fulano da Silva";
            c1.AdicionarTelefone(new Telefone(
                TipoTelefone.Residencial, "61", "2222-2222"));

            c1.AdicionarTelefone(new Telefone(TipoTelefone.Celular, "61", "9999-9999"));
            c1.Email = "fulano@hotmail.com";

            Contato c2 = new Contato();
            c2.Tipo = TipoContato.Familia;
            c2.Nome = "Ciclano da Silva";
            c2.AdicionarTelefone(new Telefone(TipoTelefone.Residencial, "61", "2222-3333"));
            c2.AdicionarTelefone(new Telefone(TipoTelefone.Trabalho, "61", "3333-4444"));
            c2.Email = "ciclano@gmail.com";

            Contato c3 = new Contato();
            c3.Tipo = TipoContato.Trabalho;
            c3.Nome = "Beltrano Pereira";
            c3.AdicionarTelefone(new Telefone(TipoTelefone.Trabalho, "61", "3333-3333"));
            c3.AdicionarTelefone(new Telefone(TipoTelefone.Celular, "61", "8888-8888"));
            c3.Email = "beltrano@yahoo.com.br";

            Agenda agenda = new Agenda("Agenda pessoal");
            agenda.AdicionarContato(c1);
            agenda.AdicionarContato(c2);
            agenda.AdicionarContato(c3);

            Program p = new Program(agenda);            
            p.apresentarTodosContatos();
            p.apresentarContatorPorTipo(TipoContato.Familia);
            
        }

        private void apresentarTodosContatos()
        {
            Console.WriteLine("******** {0} ********", agenda.Nome);
            Console.WriteLine("<<<< Todos os contatos >>>>");

            foreach (Contato c in agenda)
            {
                Console.WriteLine(c);
                Console.WriteLine();
            }
        }

        private void apresentarContatorPorTipo(TipoContato tipo)
        {
            Console.WriteLine("******** {0} ********", agenda.Nome);
            Console.WriteLine("<<<< Contatos do tipo: {0} >>>>", tipo);

            foreach (Contato c in agenda.FiltrarContatosPorTipo(tipo))
            {
                Console.WriteLine(c);
                Console.WriteLine();
            }
        }
    }
}
