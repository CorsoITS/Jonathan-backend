using _7_WebApi.Context;
using MySql.Data.MySqlClient;
using _7_WebApi.Models;

namespace _7_WebApi.Repositories;

public class OperatorRepository
{

    private AppDb appDb = new AppDb();

    public IEnumerable<Operator> GetPeople()
    {
        var result = new List<Operator>();

        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id, nome, cognome, codice_fiscale from opertore";
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operator()
            {
                Id = reader.GetInt16("id"),
                Name = reader.GetString("nome"),
                Surname = reader.GetString("cognome"),
                Fiscal_code = reader.GetString("codice_fiscale")
            };
            result.Add(operatore);
        }
        appDb.Connection.Close();

        return result;
    }

    public Operator GetPerson(int? id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "select id, nome, cognome, codice_fiscale from opertore where id=@id";
        var parameter = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameter);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var operatore = new Operator()
            {
                Id = reader.GetInt16("id"),
                Name = reader.GetString("nome"),
                Surname = reader.GetString("cognome"),
                Fiscal_code = reader.GetString("codice_fiscale")
            };
            appDb.Connection.Close();
            return operatore;
        }

        appDb.Connection.Close();
    }

    public bool Create(Operator operatore)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "insert into opertore (nome, cognome, codice_fiscale) values (@name, @surname, @Fiscal_code)";
        var parameterName = new MySqlParameter()
        {
            ParameterName = "name",
            DbType = System.Data.DbType.String,
            Value = operatore.Name
        };
        command.Parameters.Add(parameterName);
        var parameterSurname = new MySqlParameter()
        {
            ParameterName = "surname",
            DbType = System.Data.DbType.String,
            Value = operatore.Surname
        };
        command.Parameters.Add(parameterSurname);
        var parameterFiscal_code = new MySqlParameter()
        {
            ParameterName = "Fiscal_code",
            DbType = System.Data.DbType.String,
            Value = operatore.Fiscal_code
        };
        command.Parameters.Add(parameterFiscal_code);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Update(Operator operatore)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "update opertore set nome=@name, cognome=@surname, codice_fiscale=@Fiscal_code where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.String,
            Value = operatore.Id
        };
        command.Parameters.Add(parameterId);
        var parameterName = new MySqlParameter()
        {
            ParameterName = "name",
            DbType = System.Data.DbType.String,
            Value = operatore.Name
        };
        command.Parameters.Add(parameterName);
        var parameterSurname = new MySqlParameter()
        {
            ParameterName = "surname",
            DbType = System.Data.DbType.String,
            Value = operatore.Surname
        };
        command.Parameters.Add(parameterSurname);
        var parameterFiscal_code = new MySqlParameter()
        {
            ParameterName = "Fiscal_code",
            DbType = System.Data.DbType.String,
            Value = operatore.Fiscal_code
        };
        command.Parameters.Add(parameterFiscal_code);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

    public bool Delete(int id)
    {
        appDb.Connection.Open();
        var command = appDb.Connection.CreateCommand();
        command.CommandText = "delete from opertore where id=@id";
        var parameterId = new MySqlParameter()
        {
            ParameterName = "id",
            DbType = System.Data.DbType.Int16,
            Value = id
        };
        command.Parameters.Add(parameterId);
        var result = Convert.ToBoolean(command.ExecuteNonQuery());
        appDb.Connection.Close();
        return result;
    }

}