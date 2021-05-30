using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DebuggingAndTraceDemo
{
    [DebuggerDisplay("CompanyName = {_companyName}, CompanyState = {_companyState}, CompanyCity{_companyCity}")]
    public class SoftwareCompany
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private String _companyName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private String _companyState;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private String _companyCity;
        public String CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public String CompanyState
        {
            get { return _companyState; }
            set { _companyState = value; }
        }
        public String CompanyCity
        {
            get { return _companyCity; }
            set { _companyCity = value; }
        }
        public SoftwareCompany(String companyName, String companyState, String companyCity)
        {
            this._companyCity = companyCity;
            this._companyName = companyName;
            this._companyState = companyState;
        }

        [DebuggerHiddenAttribute]
        public void TesteMetodo()
        {
            Console.WriteLine("Teste Metodo");
        }
    }
}
