using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
    public class CRUDCliente:Conexao
    {
        public string Cadastro(Cliente cliente){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "insert into cliente(nome, email) values (@n, @e)";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@n",cliente.Nome);
                cmd.Parameters.AddWithValue("@e",cliente.Email);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Cliente cadastrado com sucesso";
                    else
                    mensagem = "Não foi possível cadastrar o cliente";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar cadastrar"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro Inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }

        public string Atualizar(Cliente cliente){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "update cliente set nome=@n, email=@e wherer id=@i)";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@n",cliente.Nome);
                cmd.Parameters.AddWithValue("@e",cliente.Email);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Cliente atualizado com sucesso";
                    else
                    mensagem = "Não foi possível atualizar o cliente";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar atualizar"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }

        public string Deletar(int id){
            
            string mensagem = "";
            try{
                //Vamos instanciar o objeto con
                con = new MySqlConnection();
               
                //Passar o caminho e as credenciais do banco de dados.
                con.ConnectionString = local;

                //Vamos abrir a conexão
                con.Open();

                cmd = new MySqlCommand();

                //Vamos estabelecer a relação entre os comandos de Sql com o banco de dados (con)
                cmd.Connection = con;
                //Vamos definir o tipo de comando que será executado
                cmd.CommandType = CommandType.Text;

                //Escrever o comando de Sql que será exacutado

                cmd.CommandText = "delete from cliente where id=@i";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@i", id);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Cliente deletado com sucesso";
                    else
                    mensagem = "Não foi possível deletar o cliente";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar deletar"+mse.Message;
            }
            catch (Exception ex){
                mensagem = "Erro Inesperado" + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return mensagem;
            }



                public List<Cliente> Listar(){
                    List<Cliente> ListarClientes = new List<Cliente>();

                    try{
                        //Instanciar o objeto con
                        con = new MySqlConnection();

                        //Passar o caminho e as credenciais do banco de dados
                        con.ConnectionString = local;

                        //Abrir o banco
                        con.Open();

                        //Instanciar o objeto cmd
                        cmd = new MySqlCommand();

                        cmd.Connection = con;

                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "select * from cliente";

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Cliente cli= new Cliente();
                        cli.Id = dr.GetInt32(0);
                        cli.Nome = dr.GetString(1);
                        cli.Email = dr.GetString(2);
                        cli.DataCadastro = dr.GetDateTime(3);
                        ListarClientes.Add(cli);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarClientes;
                }

                public List<Cliente> Listar(int id){
                    List<Cliente> ListarClientes = new List<Cliente>();

                    try{
                        //Instanciar o objeto con
                        con = new MySqlConnection();

                        //Passar o caminho e as credenciais do banco de dados
                        con.ConnectionString = local;

                        //Abrir o banco
                        con.Open();

                        //Instanciar o objeto cmd
                        cmd = new MySqlCommand();

                        cmd.Connection = con;

                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "select * from cliente where id=@i";
                        cmd.Parameters.AddWithValue("@i",id);

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Cliente cli= new Cliente();
                        cli.Id = dr.GetInt32(0);
                        cli.Nome = dr.GetString(1);
                        cli.Email = dr.GetString(2);
                        cli.DataCadastro = dr.GetDateTime(3);
                        ListarClientes.Add(cli);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarClientes;
                }


                

    }
}
                    
         