using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace AgendaContatos
{
    public class Agenda : IEnumerable
    {
        private string nome;
        private ArrayList contatos;

        public Agenda(string nome)
        {
            this.nome = nome;
            this.contatos = new ArrayList();
        }

        public Contato this[int indice]
        {
            get
            {
                return (Contato)contatos[indice];
            }

            set { contatos[indice] = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public void AdicionarContato(Contato contato)
        {
            contatos.Add(contato);
        }

        public void RemoverContato(Contato contato)
        {
            contatos.Remove(contato);
        }

        public void RemoverContatoDe(int indice)
        {
            contatos.RemoveAt(indice);
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return contatos.GetEnumerator();
        }

        public IEnumerable FiltrarContatosPorTipo(TipoContato tipo)
        {
            //Exemplo utilizando iterators
            foreach (Contato contato in this.contatos)
            {
                if (contato.Tipo == tipo)
                {
                    yield return contato;
                }
            }
            
            //Exemplo utilizando implementação de inumerable
            //return new EnumeravelContatosPorTipo(this, tipo);
        }



        private class EnumeravelContatosPorTipo : IEnumerable
        {
            private TipoContato tipo;
            private Agenda agenda;

            public EnumeravelContatosPorTipo(Agenda agenda, TipoContato tipo)
            {
                this.agenda = agenda;
                this.tipo = tipo;
            }


            public IEnumerator GetEnumerator()
            {
                return new EnumeradorContatosPorTipo(agenda, tipo);
            }

        #endregion
        }

        private class EnumeradorContatosPorTipo : IEnumerator
        {
            private TipoContato tipo;
            private Agenda agenda;
            private int indiceAtual = -1;

            public EnumeradorContatosPorTipo(Agenda agenda, TipoContato tipo)
            {
                this.agenda = agenda;
                this.tipo = tipo;
            }

            #region IEnumerator Members

            public object Current
            {
                get { return agenda.contatos[indiceAtual]; }
            }

            public bool MoveNext()
            {
                do { ++indiceAtual; }
                while (indiceAtual < agenda.contatos.Count &&
                    ((Contato)agenda.contatos[indiceAtual]).Tipo != tipo);

                return indiceAtual < agenda.contatos.Count;
                
            }

            public void Reset()
            {
                indiceAtual = -1;
            }

            #endregion
        }

    }
}
