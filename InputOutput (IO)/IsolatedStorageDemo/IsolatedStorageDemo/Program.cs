using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    class Program
    {
        
        //Pasta de armazenamento:
        //C:\Documents and Settings\Valued Customer\Local Settings\Application Data\IsolatedStorage\hnmve34b.qlg\ioivuivk.mod\Url.kzkvd1vrgul2iqwwosa3zj214qyts2up\AssemFiles

        static void Main(string[] args)
        {
           
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();            
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set",FileMode.Create,userStore);
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");            
            userWriter.Close();

            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("No data saved for this user");
            }
            else
            {
                userStream = new IsolatedStorageFileStream("UserSettings.set",FileMode.Open, userStore);
                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);
            }
        }
    }
}
