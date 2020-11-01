using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TP_FINAL
{
    class ListeMots
    {
        private StreamReader str = new StreamReader("../../txt/texte.txt");
        private string[] liste;
        public string[] GetLISTE{ get{ return liste; } }

        public void Lire_Fichier()
        {
            string allo = str.ReadToEnd();
            liste = allo.Split(',');
        }
    }
}
