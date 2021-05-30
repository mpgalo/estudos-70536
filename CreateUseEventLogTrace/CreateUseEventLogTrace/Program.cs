using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CreateUseEventLogTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Write("This is a traditional output"); // can use listeners to

            EventLog MyLog = new EventLog("Application", "micp100682.cemig.ad.corp", "Chapter10Demo");
            Trace.AutoFlush = true;
            EventLogTraceListener eventLogListener = new EventLogTraceListener(MyLog);
            Trace.Listeners.Add(eventLogListener);
            TextWriterTraceListener textListener = new TextWriterTraceListener(@"c:\teste.txt");
            Trace.Listeners.Add(textListener);
            XmlWriterTraceListener xmlListener = new XmlWriterTraceListener(@"c:\teste.xml");
            Trace.Listeners.Add(xmlListener);
            Trace.WriteLine("This is a test");
            
            DecoratorClass decorator = null;

            Trace.WriteIf(decorator == null, "this is a condition test");

            //Exibe mensagem de erro na tela caso o resultado seja falso
            Trace.Assert(decorator != null, "this is a assert condition test");

            //View this in quick watch
            decorator = new DecoratorClass("A Datum", "Florida", "Miami");
        }
    }

    [DebuggerDisplay("PhoneNumber = {PhoneNumbers[0]}, CompanyState = {_companyState},CompanyCity{_companyCity}")]
    public class DecoratorClass
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

        public DecoratorClass(String companyName, String companyState, String companyCity)
        {
            this._companyCity = companyCity;
            this._companyName = companyName;
            this._companyState = companyState;
        }
    }
}
