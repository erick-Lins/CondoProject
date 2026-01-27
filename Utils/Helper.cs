using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using CondoProj.Model;

namespace CondoProj.Utils
{
    public class Helper
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

        public bool IsNumeric(string input)
        {
            try
            {
                Double.Parse(input);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
