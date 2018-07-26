using System.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
    //A classe Conexão será nossa classe pai. Portanto ela foi setada como abstract, ou seja, não poderá ser intanciada.
    public abstract class Conexao
    {
        /*
        MySqlConnection permite estabelecer a conexão com o servidor de banco de dados e passar o nome do banco, nome de usuario, senha e porta de comunicação.
         */
        protected MySqlConnection con;

        //MySqlCommand permite executar os comandos de MySql(Select, Insert, Update, Delte, etc) na conexão acima.
        protected MySqlCommand cmd;

        //MySqlDataReader é um leitor de dados que retorna de um select.
        protected MySqlDataReader dr;

        //MySqlDataAdapter é outra forma mais simples de se fazer select
        protected MySqlDataAdapter adt;

        //DataTable nos ajuda a organizar os dados em fomarto tabular.
        protected DataTable dt;
        
        protected const string local = "Persist Security Info=False;database=dblojainfo;server=localhost;port=3306;sslmode=none;user=root;password=senac@tat";
        
        
    }
}