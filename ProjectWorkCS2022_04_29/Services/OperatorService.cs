using _7_WebApi.Repositories;
using _7_WebApi.Models;

namespace _7_WebApi.Service;

public class OperatorService
{

    private OperatorRepository operatorRepository = new OperatorRepository();

    public IEnumerable<Operator> GetPeople()
    {
        return operatorRepository.GetPeople();
    }

    public Operator GetOperator(int id)
    {
        return operatorRepository.GetOperator(id);
    }

    public bool Create(Operator operatore)
    {
        //insert rules for operatore's creation attributes
        if (operatorRepository.GetOperator(operatore.Id) == null)
        {
            return operatorRepository.Create(operatore);
        }
        else
        {
            return false;
        }

    }

    public bool Update(Operator operatore)
    {
        return operatorRepository.Update(operatore);
    }

    public bool Delete(int id)
    {
        return operatorRepository.Delete(id);
    }

}