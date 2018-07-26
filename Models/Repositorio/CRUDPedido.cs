using System;
using System.Collections.Generic;
using System.Data;
using LojaInfo.Models.Dominio;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LojaInfo.Models.Repositorio
{
       public class CRUDPedido : Conexao
    {
        public string Cadastrar (Pedido pedido){
            
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

                cmd.CommandText = "insert into pedido (idcliente,)values(@idc)";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idc",pedido.IdCliente);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Id do pedido cadastrado com sucesso";
                    else
                    mensagem = "Não foi possível cadastrar o id do pedido";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar cadastrar o id de pedido"+mse.Message;
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

        public string Atualizar (Pedido pedido){
            
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
                cmd.CommandText = "update detalhepedido set idcliente=idc";
                
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idc",pedido.IdCliente);

                //Vamos executar a consulta de inserção
                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Id do cliente atualizado com sucesso";
                    else
                    mensagem = "Não foi possível atualizar o id do cliente";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar atualizar o id do cliente"+mse.Message;
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

        public string Deletar(Pedido pedido){
            
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

                cmd.CommandText = "delete from pedido where idcliente=@idc";
                //Para evitar ataques de comandos de MySql de terceiros 
                cmd.Parameters.AddWithValue("@idc",pedido.IdCliente);
                
                //Vamos executar a consulta de inserção

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    mensagem = "Id do cliente deletado com sucesso";
                    else
                    mensagem = "Não foi possível deletar o id do cliente.";
                //Vamos limpar o valor presente no parâmetro
                cmd.Parameters.Clear();
            }//Fim do try
            catch (MySqlException mse){
                mensagem = "Erro ao tentar deletar o id do cliente"+mse.Message;
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



                public List<Pedido> Listar(){
                    List<Pedido> ListarPedido = new List<Pedido>();

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

                        cmd.CommandText = "select * from pedido";

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Pedido p= new Pedido();
                        p.Id = dr.GetInt32(0);
                        p.IdCliente = dr.GetInt32(1);
                        p.DataPedido = dr.GetDateTime(2);
                        ListarPedido.Add(p);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarPedido;
                }

                public List<Pedido> Listar(int id){
                    List<Pedido> ListarPedidos = new List<Pedido>();

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

                        cmd.CommandText = "select * from pedido where id=@i";
                        cmd.Parameters.AddWithValue("@i",id);

                        cmd.ExecuteReader();

                        //Enquanto houver dados presentes no dr deve ser executada a leitura destes dados.

                        while(dr.Read()){
                        //Capturar os dados de dr e montar um cliente para ser adicionado a lista de clientes
                        Pedido p= new Pedido();
                        p.Id = dr.GetInt32(0);
                        p.IdCliente = dr.GetInt32(1);
                        p.DataPedido = dr.GetDateTime(2);
                        ListarPedidos.Add(p);

                        }

                    }
                    catch(MySqlException mse){
                        throw new Exception("Erro ao tentar ler os clientes."+mse.Message);
                    }
                    finally{
                        con.Close();
                    }

                    return ListarPedidos;
                }


                

    }
}