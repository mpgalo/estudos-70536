using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace AgendaContatos
{
    public class Contato
    {
        private TipoContato tipo;
        private string nome;
        private ArrayList telefones = new ArrayList();
        private string email;

        public TipoContato Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int NumeroTelefones
        {
            get { return telefones.Count; }
        }

        public void AdicionarTelefone(Telefone telefone)
        {
            telefones.Add(telefone);
        }

        public void RemoverTelefoneDe(int indice)
        {
            telefones.RemoveAt(indice);
        }

        public Telefone RecuperarTelefone(int indice)
        {
            return (Telefone)telefones[indice];
        }

        public override string ToString()
        {
            StringBuilder contato = new StringBuilder();
            contato.AppendFormat("Tipo de contato: {0}\n", Tipo);
            contato.AppendFormat("Nom: {0}\n", Nome);

            foreach (Telefone t in telefones)
            {
                contato.AppendFormat("Telefone - {0}\n", t);
            }

            contato.AppendFormat("Email: {0}\n", email);
            return contato.ToString();
        }       
        
    }
}
