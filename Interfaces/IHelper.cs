using CondoProj.Utils;

namespace CondoProj.Interfaces
{
    public interface IHelper
    {
        bool ValidateId(int? id, bool isValidId);
        bool ValidatePronoun(string pronoun);
    }
}
