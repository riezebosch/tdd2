using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Finan
{
    class BankCodeService : IBankCodeService
    {
        private string[] bankCodes = {
                                        "INGB",
                                        "INSI",
                                        "ISBK",
                                        "KABA",
                                        "KASA",
                                        "KNAB",
                                        "KOEX",
                                        "KRED",
                                        "LOCY",
                                        "LOYD",
                                        "LPLN",
                                        "MHCB",
                                        "NNBA",
                                        "NWAB",
                                        "RABO",
                                        "RBOS",
                                        "RBRB",
                                        "SNSB",
                                        "SOGE",
                                        "STAL",
                                        "TEBU",
                                        "TRIO",
                                        "UBSW",
                                        "UGBI",
                                        "VOWA",
                                        "ZWLB",
                                     };
        public bool Contains(string code)
        {
            // Hier simuleer ik network access van een
            // webservice of database toegang.
            Thread.Sleep(5000);
            return bankCodes.Contains(code);
        }
    }
}
