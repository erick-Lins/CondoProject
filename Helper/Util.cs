using System.Diagnostics;
using System.Reflection;

namespace CondoProj.Helper
{
    public class Util
    {

        public bool ValidateId(int? id, bool isValidId)
        {
            return id > 0 && id != null && isValidId ? true : false;
        }


    }
}
