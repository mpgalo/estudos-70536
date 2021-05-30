using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaContatos
{
    public struct Telefone
    {
        private TipoTelefone tipo;
        private string ddd;
        private string telefoneLocal;

        public Telefone(TipoTelefone tipo, string ddd, string telefoneLocal)
        {
            this.tipo = tipo;
            this.ddd = ddd;
            this.telefoneLocal = telefoneLocal;
        }

        public TipoTelefone Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Ddd
        {
            get { return ddd; }
            set { ddd = value; }
        }

        public string TelefoneLocal
        {
            get { return telefoneLocal; }
            set { telefoneLocal = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}: ({1}) {2}", Tipo, Ddd, TelefoneLocal);
        }


    }
}
