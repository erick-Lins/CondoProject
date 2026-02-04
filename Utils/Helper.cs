using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using CondoProj.Interfaces;
using CondoProj.Model;
using Microsoft.AspNetCore.Mvc;

namespace CondoProj.Utils
{
    public class Helper : IHelper
    {

        public bool ValidateId(int? id, bool isValidId)
        {
            return id > 0 && id != null && isValidId ? true : false;
        }
        public bool ValidatePronoun(string pronoun)
        {
            List<string> pronoumns = new List<string>
            {
                "ele",
                "ela",
                "elu"
            };

            if (!(pronoumns.Contains(pronoun.ToLower())))
                return false;

            return true;

        }


    }
}
