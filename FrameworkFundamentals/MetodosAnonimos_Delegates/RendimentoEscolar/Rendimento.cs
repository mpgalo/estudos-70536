using System;
using System.Collections.Generic;
using System.Text;

namespace RendimentoEscolar
{
    public class Rendimento
    {
        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }
        private string aluno;

        public string Aluno
        {
            get { return aluno; }
            set { aluno = value; }
        }
        private string materia;

        public string Materia
        {
            get { return materia; }
            set { materia = value; }
        }
        private decimal nota1b;

        public decimal Nota1b
        {
            get { return nota1b; }
            set { nota1b = value; }
        }
        private decimal nota2b;

        public decimal Nota2b
        {
            get { return nota2b; }
            set { nota2b = value; }
        }
        private decimal nota3b;

        public decimal Nota3b
        {
            get { return nota3b; }
            set { nota3b = value; }
        }
        private decimal nota4b;

        public decimal Nota4b
        {
            get { return nota4b; }
            set { nota4b = value; }
        }
        private CalcularMedia calcularMediaFinal;

        public CalcularMedia CalcularMediaFinal
        {
            get { return calcularMediaFinal; }
            set { calcularMediaFinal = value; }
        }

        public Rendimento() { }
        public Rendimento(string matricula, string aluno, string materia)
        {
            this.matricula = matricula;
            this.aluno = aluno;
            this.materia = materia;
        }

        private decimal calcularMediaFinalPadrao(decimal nota1b, decimal nota2b, decimal nota3b, decimal nota4b)
        {
            return (nota1b + nota2b + nota3b + nota4b) / 4;
        }

        public decimal MediaFinal
        {
            get
            {
                if (CalcularMediaFinal == null)
                    return calcularMediaFinalPadrao(Nota1b, Nota2b, Nota3b, Nota4b);
                else
                    return CalcularMediaFinal(Nota1b, Nota2b, Nota3b, Nota4b);
            }
        }
    }
}
